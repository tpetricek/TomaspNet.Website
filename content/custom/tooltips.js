var currentTip = null;
var currentTipElement = null;

function hideTip(evt, name, unique)
{
  var el = document.getElementById(name);
  el.style.display = "none";
  currentTip = null;
}

function findPos(obj)
{
  var curleft = 0;
  var curtop = obj.offsetHeight;
  while (obj)
  {
    curleft += obj.offsetLeft;
    curtop += obj.offsetTop;
    obj = obj.offsetParent;
  };
  return [curleft, curtop];
}

function hideUsingEsc(e)
{
  if (!e) { e = event; }
  hideTip(e, currentTipElement, currentTip);
}

function showTip(evt, name, unique, owner)
{
  document.onkeydown = hideUsingEsc;
  if (currentTip == unique) return;
  currentTip = unique;
  currentTipElement = name;

  var pos = findPos(owner ? owner : (evt.srcElement ? evt.srcElement : evt.target));
  var posx = pos[0];
  var posy = pos[1];

  var el = document.getElementById(name);
  var parent = (document.documentElement == null) ? document.body : document.documentElement;
  parent.appendChild(el);
  el.style.position = "absolute";
  el.style.left = posx + "px";
  el.style.top = posy + "px";
  el.style.display = "block";
}