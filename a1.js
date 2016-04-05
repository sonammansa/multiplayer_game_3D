#pragma strict
var firesound : AudioClip;
function Start () {

}
  function Update () {

}

function OnMouseDown()
{
    Destroy (gameObject);
    audio.enabled = true;
    audio.Stop();
    audio.PlayOneShot(firesound);

}