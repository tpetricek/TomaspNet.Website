namespace TildeLib

type Post = 
  { Url : string
    Title : string 
    Date : System.DateTime
    Tags : string[] 
    Description : string }

type Site () = 
    static member val Posts : Post[] = [||] with get,set    
    static member val Url = "" with get,set
