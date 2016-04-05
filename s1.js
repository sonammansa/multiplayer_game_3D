#pragma strict

var go : GameObject;

function Update()
{  
}
 function OnMouseDown () {
 go.transform.position=renderer.transform.position;
 go.transform.rotation=renderer.transform.rotation; 

}


function Start () {

}

