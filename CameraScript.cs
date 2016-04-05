using UnityEngine;
using System.Collections;


public class CameraScript : MonoBehaviour {
	public Camera rearCamera;
    public Camera driverCamera ;
	public Transform car;
	public Transform terrain;
	public float distance=6.4f;
	public float height=1.4f;
	public float rotationDamping=3.0f;
	public float heightDamping=2.0f;
	public float zoomRacio=0.5f;
	public float DefaultFOV=60.0f;
	private Vector3 rotationVector;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		float wantedAngel  =  rotationVector.y;

float wantedHeight = car.position.y + height;

float myAngel = transform.eulerAngles.y;

float myHeight = transform.position.y;

myAngel = Mathf.LerpAngle(myAngel,wantedAngel,rotationDamping*Time.deltaTime);

myHeight = Mathf.Lerp(myHeight,wantedHeight,heightDamping*Time.deltaTime);

Quaternion currentRotation = Quaternion.Euler(0,myAngel,0);

transform.position = car.position;

transform.position -= currentRotation*Vector3.forward*distance;
		
rearCamera.camera.enabled = false;
        driverCamera.camera.enabled = true;

//transform.position.y = myHeight;

transform.LookAt(car);
if (Input.GetKey("f")) {
			float wanteAngel  =  rotationVector.y + 10000;

float wanteHeight = terrain.position.y + 1000;

float myAnge = transform.eulerAngles.y + 1000;

float myHeigh = transform.position.y + 1000;

myAnge = Mathf.LerpAngle(myAngel,wanteAngel,rotationDamping*Time.deltaTime);

myHeigh = Mathf.Lerp(myHeigh,wanteHeight,heightDamping*Time.deltaTime);

Quaternion currenRotation = Quaternion.Euler(0,myAngel,0);

transform.position = terrain.position;

transform.position -= currenRotation*Vector3.forward*distance;

//transform.position.y = myHeight;

transform.LookAt(terrain);
			 driverCamera.camera.enabled = false;
        rearCamera.camera.enabled = true;
		}
		

	
	}
}
