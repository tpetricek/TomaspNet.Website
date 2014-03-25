(**
<div id="myModal" class="reveal-modal xlarge" data-reveal>
  <iframe src="http://tomasp.net/blog/2013/japan-advent-art/hokusai.html" style="width:100%; height:850px;border-style:none;"></iframe>
  <a class="close-reveal-modal">&#215;</a>
</div>

<div class="rdecor" style="text-align:center">
<a href="#" data-reveal-id="myModal" style="text-align:center">
<img src="http://tomasp.net/blog/2013/japan-advent-art/hokusai_sm.jpg" style="margin-bottom:10px;border:4px solid black" title="神奈川沖浪裏 (The Great Wave off Kanagawa)" /><br />
<small style="font-size:90%">実際の結果を見るにはここをクリック！</small>
</a>
</div>

ここ数年、日本のF# コミュニティは「F# Advent Calendar」というイベントを開催しています
([2010年](http://atnd.org/events/10685)、
[2011年](http://partake.in/events/1c24993a-c475-4fc2-bca4-7a1cd2f81869)、
[2012年](http://atnd.org/events/33927)、
そして [今年](http://connpass.com/event/3935/))。
これはadvent dayごとに1人ずつ、F#に関連した何かしら興味深い記事を作成するというものです。
私は去年からTwitterでadvent calendarをチェックしていて、
今年からは私も参加しようと思い、記事を書きたいと申し出ました。
そうしたところ、数名の方からの協力を得ることができました。
[@@igeta](https://twitter.com/igeta) には参加手続きの諸々とレビューを、
[@@yukitos](http://twitter.com/yukitos) にはこの記事の翻訳を、そして
[@@gab_km](http://twitter.com/gab_km) には翻訳のレビューをしていただきました。
ありがとう！

けれども何についての記事を書くのがよいのでしょう？
過去一年にわたって、F#コミュニティで開発されているF#のオープンソースライブラリやプロジェクトを
いくつか紹介できるような記事がよさそうです。
それと同時に、日本に関連のあるトピックが何かないものでしょうか？
少し考えてみたところ、以下のようなプランを思いつきました：

 * まず、日本の絵画について学ぶために [F# Data][fsdata] ライブラリと [Freebase](http://www.freebase.com) を組み合わせて使う。
   このライブラリにはいまや [日本語ドキュメント][fsdatajp] があり、作成してくれた [@@yukitos](https://twitter.com/yukitos) に感謝しています。

 * そして絵画作品を1つ選択して、F#でその作品を再生成する。
   私の絵画スキルでは到底無理なのですが、試してみることはできます :-)

 * 最後に、 [FunScriptプロジェクト](http://funscript.info) を使って
   F#コードをJavaScriptに変換します。
   そうすると純粋なHTML Webアプリケーションとして実行できるようになり、
   携帯電話やその他のデバイスでも動作するようになります。

[fsdata]: http://fsharp.github.io/FSharp.Data/
[fsdatajp]: https://github.com/fsharp/FSharp.Data/blob/master/docs/content/ja/index.md
*)