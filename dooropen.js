#pragma strict


var smooth = 2.0;
var DoorOpenAngle = 90.0;
private var open : boolean;
private var enter : boolean;

private var defaultRot : Vector3;
private var openRot : Vector3;

//function Start(){
//defaultRot = transform.eulerAngles;
//openRot = new Vector3 (defaultRot.x, defaultRot.y + DoorOpenAngle, defaultRot.z);
//}

//Main function
 /* function OnMouseDown() {
        // Slowly rotate the object around its X axis at 1 degree/second.
        transform.Rotate(Vector3.down, 240*Time.deltaTime);
        // ... at the same time as spinning it relative to the global 
        // Y axis at the same speed.
        //transform.Rotate(Vector3.up, Time.deltaTime, Space.World);
    }
   */ 
    function OnMouseOver () 
{
    if(Input.GetMouseButtonDown(0))
        {
        transform.Rotate(Vector3.down, 240*Time.deltaTime);
        }
    if(Input.GetMouseButtonDown(1))
        transform.Rotate(Vector3.up, 240*Time.deltaTime);
        
    if(Input.GetMouseButtonDown(2))
        Debug.Log("Middle click on this object");
}