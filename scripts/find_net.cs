using UnityEngine;
using System.Collections;
//using UnityEditor;

public class find_net : Photon.MonoBehaviour {
	
	public string tar;
	public GUIText btnTexts;
	public GUIText cl;
	public bool ispaused=false;
	//public float starttime;
	public int chk=0;
	public float t;
	public GUIText clue;
	public GameObject go;
	public GameObject pl;
	public string un;
	//public int lev=1;
	public int show=0;
	//public net nn=new net();
	// Use this for initialization
	void Start () {
		net.wnr=new int[10];
		net.wnr[PhotonNetwork.player.ID-1]=0;
		/*for(int k=0;k<10;k++)
		{
		net.wnr[k]=0;	
		}*/
		net.lev=net.lev+1;
		btnTexts.text += "Level "+net.lev;
		un=net.arr[PhotonNetwork.player.ID-1];
		Debug.Log("fname:"+un+" id:"+PhotonNetwork.player.ID+" lev:"+net.lev);
		clue.text="clues";
		if(net.lev==1)
		{
			Vector3 temp = new Vector3((float)243.837,(float)8.037416,(float)243.4043);
			Quaternion temp1 = new Quaternion((float)0,(float)234.7792,(float)0,(float)0);
			pl.transform.position = temp;
			pl.transform.rotation= temp1;
		
		}
		else if(net.lev==2)
		{
		Vector3 temp = new Vector3((float)695.8889,(float)0.04491125,(float)742.2939);
			pl.transform.position = temp;
		
			
		}
		else if(net.lev==3)
		{
		Vector3 temp = new Vector3((float)674.1865,(float)0.01767454,(float)25.81096);
			Quaternion temp1 = new Quaternion((float)0,(float)134.5918,(float)0,(float)0);
			pl.transform.position = temp;
			pl.transform.rotation= temp1;
		
				
		}else if(net.lev==4)
		{
		Vector3 temp = new Vector3((float)350.2126,(float)0.004020497,(float)700.8123);
			pl.transform.position = temp;
		}
		else
		{
		Application.LoadLevel("loc1");	
		}
		
		//starttime = 300;
	}
	RaycastHit hit;
	// Update is called once per frame
	void Update () {
	 if (Input.GetMouseButtonDown(0)){ // if left button pressed...
    Ray ray = camera.ScreenPointToRay(Input.mousePosition);
    
    if (Physics.Raycast(ray, out hit)){
			//print(hit.transform.name+" and "+tar);
     if(hit.transform.name==tar && chk==1 && rt>0)
					
				{	
					//Destroy(hit);
					go.transform.position=hit.transform.position;
					go.transform.rotation=hit.transform.rotation;
					//net.scr[PhotonNetwork.player.ID-1]=net.scr[PhotonNetwork.player.ID-1]+10;
					show=1;
					//net.wnr[PhotonNetwork.player.ID-1]=1;
					photonView.RPC("incscr",PhotonTargets.AllBuffered,PhotonNetwork.player.ID);
			
					Debug.Log(PhotonNetwork.player.ID + "found sc:"+net.scr[PhotonNetwork.player.ID-1]+" wn:"+net.wnr[PhotonNetwork.player.ID-1]);
					tar="";
					photonView.RPC("showfound",PhotonTargets.AllBuffered,un);
						
					//networkView.RPC("showfound",RPCMode.AllBuffered,Network.player.guid);
				}
				
    }
			
  }
		if(show==1)
				{
					if(net.lev==4)
				{
					cl.text="HURRAY!! You won the game!";
				cl.text +=" Your score:"+net.scr[PhotonNetwork.player.ID-1];
				}
				else
				{
				cl.text="HURRAY!! You reached next level! Please wait for other players to complete.";
				
		cl.text +=" Your score:"+net.scr[PhotonNetwork.player.ID-1];
				}
				}
			/*if(chk==1 && cl.text!="HURRAY!! You reached level 2! Please wait for other players to complete.")
		{
			Debug.Log("find time");
		//Debug.Log("start "+starttime+" and time "+ (Time.time-f));
		timer = starttime - (Time.timeSinceLevelLoad -(t)); 
		//Debug.Log("rem "+timer);
		if (timer < 0) 
		{
 		timer = 0;
 		ispaused = true;
  		}
		time();
		}*/
	}
	
	void OnGUI()
	{

				GUI.Label(new Rect(100,50,300,25),"Welcome "+un+". You are on Level "+net.lev);
				//GUI.Label(new Rect(100,100,100,25),"waiting for client to hide");
				if(GUI.Button(new Rect(100,125,100,25),"Logout"))
				{
			PhotonNetwork.Disconnect();
				//Network.Disconnect(250);
				Application.LoadLevel("loc1");
				}
		
	}
	
	
	[RPC]
	void nextlev(int g)
	{
		int g1=PhotonNetwork.player.ID;
		print(g +":rand and this:"+g1);
		if(g==g1 && show==1)
		{
			Application.LoadLevel("hide1");
		}
		
		else if(show==1)
		{
		Application.LoadLevel("find1");
		}	
		
		else if(show==0)
		{
		Application.LoadLevel("loc1");	
		}
		
	}
	
	[RPC]
	void showcl(string c)
	{
		if(tar!="")
		{
		Debug.Log("clue="+c);
		clue.text += "\n"+c;
		}
	}
	
	//public string un="";

	[RPC]
	void incscr(int id)
	{
		if(net.lev==1)
	net.scr[id-1]=10;
		else if(net.lev==2)
		net.scr[id-1]=20;
		else if(net.lev==3)
		net.scr[id-1]=30;
		else if(net.lev==4)
		net.scr[id-1]=40;
		net.wnr[id-1]=1;
	}
	
	[RPC]
	void showfound(string nm)
	{
		
		btnTexts.text += "\n" +nm+ " found the object";
	//GUI.Label(new Rect(300,100,100,30),id+" found the object");	
	}
					
		[RPC]
	void targetval(string ob)
	{
		tar=ob;
		chk=1;
		t=Time.timeSinceLevelLoad;
		
			Debug.Log("tar is:"+tar);
	}
	public float rt=0;
	
	[RPC]
	void time(float tr)
	{
		Debug.Log("findtime");
		if(chk==1 && show==0)
		{
			rt=tr;
			float tt=Time.timeSinceLevelLoad -(t);
	
		int minutes;
 		int seconds;
 		string timeStr;
 		minutes = (int)tr/60;
 		seconds = (int)tr % 60;
 		timeStr = minutes.ToString("D2") + ":";
 		timeStr += seconds.ToString("D2");
 		cl.text = timeStr; //display the time to the GUI
			Debug.Log("ffrt:"+tr);
		if(tr==0)
		{
				Debug.Log("fscoress:"+net.scr[0]+" "+net.scr[1]+" "+net.scr[2]+" "+net.scr[3]+" "+net.scr[4]+" "+net.scr[5]+" "+net.scr[6]+" "+net.scr[7]+" "+net.scr[8]+" "+net.scr[9]);
			
				tar="";
 			cl.text="TIME IS UP!! You lost. Your score:"+net.scr[PhotonNetwork.player.ID-1];
			//Application.LoadLevel("timeup");
		}
		}
	}
}
