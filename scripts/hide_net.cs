using UnityEngine;
using System.Collections;
//using UnityEditor;

public class hide_net : Photon.MonoBehaviour {
	RaycastHit hit;
	//string someInfo = "";
	public string o;
	public string tar;
	public GUIText btnTexts;
	public GUIText cl;
	public bool ispaused=false;
	public float starttime;
	public float timer;
	public int chk=0;
	public float t;
	public GUIText clue;
	public string incl="";
	public string un;
	public GameObject pl;
    private NetworkPlayer _myNetworkPlayer;
	//public net nn=new net();
	//public int lev=1;
	
	void Start()
	{
		w=0;
		cl.text="";
		net.wnr=new int[10];
		net.wnr[PhotonNetwork.player.ID-1]=0;
		/*for(int k=0;k<10;k++)
		{
		net.wnr[k]=0;	
		}*/
		
		net.lev=net.lev+1;
		//btnTexts.text += "Level "+net.lev;
	un=net.arr[PhotonNetwork.player.ID-1];
		Debug.Log("hname:"+un+" id:"+PhotonNetwork.player.ID+" lev:"+net.lev);
		//un=nn.list[nn.x];
	//Debug.Log("hide:"+nn.list[0]);
	starttime = 180 ;
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
	}
	
	void Update(){
  if (Input.GetMouseButtonDown(0)){ // if left button pressed...
    Ray ray = camera.ScreenPointToRay(Input.mousePosition);
    
    if (Physics.Raycast(ray, out hit)){
		 o=hit.transform.name;
			//Debug.Log("hit"+o);	
			}
  }
		if(chk==1)
		{
		//Debug.Log("start "+starttime+" and time "+ (Time.time-f));
			timer = starttime - (Time.timeSinceLevelLoad -(t));
		if (timer < 0) 
		{
 		timer = 0;
 		ispaused = true;
		}
			photonView.RPC("time",PhotonTargets.AllBuffered,timer);
		//time();
		}
}
	public string s;
	void OnGUI()
	{

			
			//Debug.Log("nn.x is:"+nn.x);
			//un=nn.list[nn.x];
			//Debug.Log("un is "+un);
			GUI.Label(new Rect(100,50,300,25),"Welcome "+un+". You are on Level "+net.lev);
			if(chk==1)
			{
				incl=GUI.TextField(new Rect(700,65,200,100),incl,40);
			if(GUI.Button(new Rect(700,165,100,25),"send clue"))
					{
					s=incl;
					incl="";
						Debug.Log("sending");
			photonView.RPC("showcl",PhotonTargets.OthersBuffered,s);		
			//networkView.RPC("showcl",RPCMode.OthersBuffered,s);
					}
			}
				//GUI.Label(new Rect(100,100,100,25),"client");
				if(GUI.Button(new Rect(100,175,100,25),"Logout"))
				{
				PhotonNetwork.Disconnect();
				//Network.Disconnect(250);
				Application.LoadLevel("loc1");
				}
			if(chk==0)
			{
			GUI.Label(new Rect(100,115,400,25),"Hide the ball in any object by clicking on it and then click ok.");
				if(GUI.Button(new Rect(100,200,100,25),"done"))
				{
				//networkView.RPC("SendInfoToServer",RPCMode.Server,o);
					//print (o);
			//SendInfoToServer(o);
				Debug.Log("obj"+o);
				//net.obj=o;
				if(o=="" || o=="Terrain")
				{
					GUI.Label(new Rect(100,140,300,25),"Invalid object. Cant hide here. Hide the ball in some other object.");
					Debug.Log("no object");
					
				}
				else
				{
					//incl=GUI.TextField(new Rect(300,125,200,200),incl,40);
					//clue.text="clue";
					chk=1;
					photonView.RPC("targetval",PhotonTargets.AllBuffered,o);
					//networkView.RPC("showobj",RPCMode.Server,o);
					
				}
			}
			}
	}
	
	
	
	[RPC]
	void showcl(string c)
	{
		
	}
	
	
	
	
		
	/*[RPC]
	void showobj(string ob)
	{	}*/
		[RPC]
	void targetval(string ob)
	{
		tar=ob;
		t=Time.timeSinceLevelLoad;
	}
	public int w=0;
	public int q=0;
	public int ov=0;
	
	[RPC]
	void time(float tr)
	{
		Debug.Log("hidetime");
		int minutes;
 		int seconds;
 		string timeStr;
 		minutes = (int)tr/60;
 		seconds = (int)tr % 60;
 		timeStr = minutes.ToString("D2") + ":";
 		timeStr += seconds.ToString("D2");
 		cl.text = timeStr; //display the time to the GUI
		if(cl.text=="02:00" && btnTexts.text=="Hope2Find" && w==0)
		{
		if(net.lev==4)
		{
		starttime=0;
		}
			//net.scr[PhotonNetwork.player.ID-1]=net.scr[PhotonNetwork.player.ID-1]+10;
			photonView.RPC("incscr",PhotonTargets.AllBuffered,PhotonNetwork.player.ID);
			Debug.Log("hide won"+cl.text+btnTexts.text+tr);
		w=1;	
			//photonView.RPC("incscr",PhotonTargets.AllBuffered,PhotonNetwork.player.ID);
			
			//net.wnr[PhotonNetwork.player.ID-1]=1;
		}
 		if(tr==0)
		{
			if(w==0)
			{
 			cl.text="Sorry, You lost!! Some players found your object within 1 minute. Your score:"+net.scr[PhotonNetwork.player.ID-1];
			Debug.Log("hscoress:"+net.scr[0]+" "+net.scr[1]+" "+net.scr[2]+" "+net.scr[3]+" "+net.scr[4]+" "+net.scr[5]+" "+net.scr[6]+" "+net.scr[7]+" "+net.scr[8]+" "+net.scr[9]);
			}
			else
			{
				if(net.lev==4)
				{
					cl.text="HURRAY!! You won the game!";
					cl.text +=" Your score:"+net.scr[PhotonNetwork.player.ID-1];
				}
				else
				{
				cl.text="HURRAY!! You reached next level!";
				
		cl.text +=" Your score:"+net.scr[PhotonNetwork.player.ID-1];
				}
				//photonView.RPC("showfound",PhotonTargets.AllBuffered,un);
				//networkView.RPC("showfound",RPCMode.Server,Network.player.guid);
				
			}
			if(ov==0&& net.lev!=4)
			{
			int lv=net.lev+1;
				//GUILayout.Label("Loading level "+lv);
				int g=0;
				//int[] x=new int[10]; 
				
				do
				{
			Debug.Log("scoress:"+net.scr[0]+" "+net.scr[1]+" "+net.scr[2]+" "+net.scr[3]+" "+net.scr[4]+" "+net.scr[5]+" "+net.scr[6]+" "+net.scr[7]+" "+net.scr[8]+" "+net.scr[9]);
			Debug.Log("winnerss:"+net.wnr[0]+" "+net.wnr[1]+" "+net.wnr[2]+" "+net.wnr[3]+" "+net.wnr[4]+" "+net.wnr[5]+" "+net.wnr[6]+" "+net.wnr[7]+" "+net.wnr[8]+" "+net.wnr[9]);
			g=Random.Range(0,9);
						Debug.Log("score:"+net.scr[g]+" and g:"+g);
				}while(net.scr[g]==0);
				
			
		//string g= Network.connections[x].guid ;
			print("hrand "+g);
				ov=1;
	//photonView.RPC("loadl",PhotonTargets.AllBuffered,g);
			photonView.RPC("nextlev",PhotonTargets.AllBuffered,g+1);
			}
			if(q==0)
			{
				q=1;
				Debug.Log("in it");
			//networkView.RPC("winners",RPCMode.Server);
			}
		}
	}
	
	
	/*[RPC]
	void winners()
	{}*/
	
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
	void nextlev(int g)
	{
	int g1=PhotonNetwork.player.ID;
		print(g +":rand and this:"+g1);
		if(g==g1 && w==1)
		{
			Application.LoadLevel("hide1");
		}
		
		else if(w==1)
		{
		Application.LoadLevel("find1");
		}
		else if(w==0)
		{
		Application.LoadLevel("loc1");	
		}
	}
	
	[RPC]
	void showfound(string nm)
	{
		btnTexts.text += "\n" +nm+" found the object";
		if(net.lev==4)
		{
		starttime=0;	
		}
		/*btnTexts = new GUIText();
		GameObject go = new GameObject(id+" found the object"); 
	 btnTexts = go.AddComponent<GUIText>();*/
		
	//GUI.Label(new Rect(300,100,100,30),id+" found the object");	
	}
	/*[RPC]
    void SendInfoToServer(string msg){
		
        someInfo = "Client " + _myNetworkPlayer.guid + ": object is "+msg ;
		networkView.RPC("ReceiveInfoFromClient", RPCMode.Server, someInfo);

    }
	
	 [RPC]
    void ReceiveInfoFromClient(string someInfo) { 
	}*/
}
