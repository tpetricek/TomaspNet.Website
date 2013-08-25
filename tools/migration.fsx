#r "System.Data.Linq.dll"
#r "FSharp.Data.TypeProviders.dll"
open System
open System.Linq
open Microsoft.FSharp.Data.TypeProviders
open System.Xml

// --------------------------------------------------------------------------------------
// Reading data from the old database format
// --------------------------------------------------------------------------------------

type DB = SqlDataConnection< @"Data Source=.\SQLExpress;Integrated Security=True;Initial Catalog=tomasp_data">
let db = DB.GetDataContext()

// --------------------------------------------------------------------------------------
// Do various crazy processing on the article item
// --------------------------------------------------------------------------------------

let readBlogItem (item:DB.ServiceTypes.Content, tags:seq<string>) =
  let description = item.Description
  let date = item.Date

  // try to load page as a xml document - if it fails then we need to combine 
  // the document from 'contentintro' and from 'the value stored in 'content'
  let doc = new XmlDocument(PreserveWhitespace = true)
  try 
    doc.LoadXml(item.Content1)
    if doc.DocumentElement.Name <> "doc" then failwith "New format.."
  with _ ->
    // generate v2 document from two columns
    doc.PreserveWhitespace <- true
    let s = if String.IsNullOrWhiteSpace(item.Content1) 
            then item.Contentintro else item.Content1
    doc.LoadXml
      ( "<doc hidedescr=\"true\" version=\"2\"><intro>" + item.Contentintro +
        "</intro><body>" + s + "</body></doc>" )

  let content = doc.SelectSingleNode("doc/body").InnerXml

  let content, title, description = 
    if doc.DocumentElement.Attributes.["version"].Value = "1" then
      // Version 1 is just a HTML code that conatins "H1"
      item.Content1, item.Header, item.Description
    else 
      // Version "2" contains a few additional information in the <doc> element
      "<h1>" + item.Header + "</h1>\n" + item.Content1, item.Header, item.Description

  item.Urlname, title, date, description, tags, content

// --------------------------------------------------------------------------------------
// Save the item to a file
// --------------------------------------------------------------------------------------

open System.IO
open System.Text.RegularExpressions

let blogDir = @"C:\Tomas\Projects\WebSites\TomaspNet.New\website\source\blog"
let regStrAtAtStr = Regex("[a-zA-Z]@@[a-zA-Z]")

let writeBlogItem (url, title, (date:System.DateTime), (description:string), tags, (content:string)) =
  printfn "Generating: %s.html" url
  let encodeString (s:string) = 
    s.Replace("\"", "\\\"").Replace('\n', ' ').Replace('\r', ' ')
  let header =
    sprintf """@{ 
      Layout = "post";
      Title = "%s";
      Tags = "%s";
      Date = "%O";
      Description = "%s";
    }""" (encodeString title) (String.concat "," tags) date (encodeString description)
  // We need to encode the '@' symbol in content, but apparently not when there is string around
  let rec fixAtAt str = 
    let mtc = regStrAtAtStr.Match(str)
    if mtc.Success then 
      let str = str.Substring(0, mtc.Index + 1) + "@" + (str.Substring(mtc.Index + 3))
      fixAtAt str
    else str
  let content = content.Replace("@", "@@") |> fixAtAt

  File.WriteAllText(blogDir + "\\" + url + ".aspx.html", header + content)

// --------------------------------------------------------------------------------------
// Read items that appear in blog/article
// --------------------------------------------------------------------------------------

query { for v in db.Content do
        leftOuterJoin ct in db.Content_type on (v.Id = ct.Content_id) into cts
        leftOuterJoin tg in db.Allcontent_tags on (v.Id = tg.Content_id) into tags
        let types = query { for ct in cts do
                            for ty in db.Types do
                            where ((ct:DB.ServiceTypes.Content_type).Type_id = ty.Id)
                            select ty.Name }
        let tagNames = query { for t in tags do 
                               for tn in db.Tags do
                               where ((t:DB.ServiceTypes.Allcontent_tags).Tag_id = tn.Tag_id) 
                               where (tn.Type = "blog")
                               select tn.Tag }
        where (types.Contains("articles") || types.Contains("blog"))
        sortByDescending v.Date
        select (v, tagNames) }
|> Seq.skip 7 // Skip those done by hand :)
|> Seq.map readBlogItem
|> Seq.iter writeBlogItem
