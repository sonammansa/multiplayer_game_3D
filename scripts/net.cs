using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class net : Photon.MonoBehaviour {

public string ip="127.0.0.1";
	public int port= 25000;
public static string obj;
	public GUIText btnTexts;
	public GUIText winn;
	// public int pc=0;
	public int check=0;
	public string tar;
	public string name="";
	public string un;
	public List<string> list=new List<string>();
	public int x;
	public int serv=0;
	static public bool connecting = false;
	static public bool connected = false;
	public static string[] arr;
	public static int[] scr;
	public static int[] wnr;
	public static int lev=0;
	
	
	void Start () {
		arr=new string[10];
		scr=new int[10];
		arr[PhotonNetwork.player.ID-1]=" ";
		scr[PhotonNetwork.player.ID-1]=0;
		connecting = false;
		connected = false;
	
	}
	
	RaycastHit hit;
	void Update () {
	 if (Input.GetMouseButtonDown(0)){ // if left button pressed...
    Ray ray = camera.ScreenPointToRay(Input.mousePosition);
    
    if (Physics.Raycast(ray, out hit)){
				if(hit.transform.name=="how to play")
				{
				Application.LoadLevel("howto");	
				}
			}
			
		}
	}
	
	/*void OnPlayerConnected(NetworkPlayer player) {
     //networkView.RPC("targetval",RPCMode.Others,obj);
		pc++;
		print("players:"+player.guid);
		Debug.Log("npc:"+pc);
		if(pc>=4)
		{
			x=Random.Range(1,pc);
		string g= Network.connections[x].guid ;
			print("rand "+g);
			networkView.RPC("loadl",RPCMode.OthersBuffered,g);
		}
    }
	
	 void OnPlayerDisconnected(NetworkPlayer player) {
        pc--;
		Debug.Log("npd:"+pc);
        Network.RemoveRPCs(player);
        Network.DestroyPlayerObjects(player);
		Network.CloseConnection(player,false);
    }*/
	
	void OnGUI()
	{
		//GUILayout.FlexibleSpace();
		GUI.Label(new Rect(400,450,100,25),"Instructions: ");
		GUI.Label(new Rect(500,450,500,500),"The game will start when atleast 4 players will join the game. The player who is given to hide an object will hide it anywhere and then click on done. Other players have to find it within 3 minutes to reach the next level otherwise he loses the game. The one who hides will reach next level if no one is able to find the object within 1 minute. There are total 4 levels, the one who wins the last level wins the game.");
			if(!connecting && lev==0) {
			GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString());
			GUILayout.BeginArea( new Rect(Screen.width/2 - 100, 0, 200, Screen.height) );
			GUILayout.BeginVertical();
			GUILayout.FlexibleSpace();
			
			GUILayout.Label("Your Name: ");
			name = GUILayout.TextField(name, 24);
			
			GUILayout.Space(20);
			if(name.Length > 0 && GUILayout.Button("Enter Game")) {
				connecting = true;
				PhotonNetwork.ConnectUsingSettings("Level1");
				
				
			}
			
			GUILayout.FlexibleSpace();
			GUILayout.EndVertical();
			GUILayout.EndArea();
		}
		else if(!connected) {
			GUILayout.BeginArea( new Rect(Screen.width/2 - 100, 300, 200, Screen.height) );
			GUILayout.BeginVertical();
			GUILayout.FlexibleSpace();
			GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString());
		
			
		}
		else if(connected)
		{
			GUILayout.BeginArea( new Rect(Screen.width/2 - 100, 300, 400, Screen.height) );
			GUILayout.BeginVertical();
			GUILayout.FlexibleSpace();
			
			GUILayout.Label("Hello "+arr[PhotonNetwork.player.ID-1]+"."+ PhotonNetwork.player.ID+"Please wait for more players to connect.");
			
			
		}
		/*if(Network.peerType==NetworkPeerType.Disconnected)
		{
				Debug.Log("serv:"+serv);
			if(serv==0)
			{
		if(GUI.Button(new Rect(100,150,100,25),"Start"))
			{
					serv=1;
				Network.InitializeServer(50,port);
				
				//Network.InitializeServer(50,port, !Network.HavePublicAddress());
				//MasterServer.RegisterHost("hope2find", "shubhi", "hunting game");
			}
			}
			else if(serv==1)
			{
			name=GUI.TextArea(new Rect(100,100,100,25),name);
		if(GUI.Button(new Rect(100,125,100,25),"Login"))
			{
				print ("client");*/
				
				/*MasterServer.RequestHostList("hope2find");
				  if (MasterServer.PollHostList().Length != 0) {
            HostData[] hostData = MasterServer.PollHostList();
            int i = 0;
            while (i < hostData.Length) {
                Debug.Log("Game name: " + hostData[i].gameName);
                i++;
            }
				}*/
				//Network.Connect(data);
				/*Network.Connect(ip,port);
			
				
			}
			}
		
		}
		else
		{
			if(Network.peerType==NetworkPeerType.Client)
			{
				list.Add(name);
					//PlayerPrefs.SetString(name,name);
				//un=PlayerPrefs.GetString(name);
				un=name;
				GUI.Label(new Rect(100,100,300,25),"Hi,"+list[pc]+". Waiting for more players to connect.");
				if(GUI.Button(new Rect(100,125,100,25),"Logout"))
				{
				Network.Disconnect(250);
				}*/
				/*if(GUI.Button(new Rect(100,150,100,25),"hide"))
				{
				Application.LoadLevel("hide");
				}
				if(GUI.Button(new Rect(100,175,100,25),"find"))
				{
				Application.LoadLevel("find");
				}*/
								
			/*}
			if(Network.peerType==NetworkPeerType.Server)
			{
				GUI.Label(new Rect(100,100,100,25),"server");
				GUI.Label(new Rect(100,125,100,25),"Connections" + Network.connections.Length);
				if(GUI.Button(new Rect(100,150,100,25),"Logout"))
				{
				Network.Disconnect(250);
				}*/
				
				/*int x=Random.Range(1,Network.connections.Length);
				print(Network.connections[0].guid + " random no. " +x);*/
				
				  // GUI.Label(new Rect(100, 175, 100, 25), obj);
			/*}
		}*/
		
	}
	
	void OnJoinedLobby() {
		PhotonNetwork.JoinRandomRoom();
		Network.Connect(ip,port);
	}
	
	void OnPhotonRandomJoinFailed() {
		PhotonNetwork.CreateRoom(null);
		Network.InitializeServer(10,port,false);
	}
	public int d=0;
	
	void OnJoinedRoom() {
		arr[PhotonNetwork.player.ID-1]=name;
		connected = true;
		//GameObject player=PhotonNetwork.Instantiate("player",Vector3.zero,Quaternion.identity,0);
		//print("players:"+ player.guid);
		Debug.Log("npc:"+PhotonNetwork.playerList.Length);
		if( PhotonNetwork.playerList.Length==4)
		{
			Debug.Log("yes");
			x=Random.Range(0,PhotonNetwork.playerList.Length-1);
			int g=PhotonNetwork.playerList[x].ID;
		//string g= Network.connections[x].guid ;
			print("rand "+g);
	photonView.RPC("loadl",PhotonTargets.AllBuffered,g);
			d=1;
			//networkView.RPC("loadl",RPCMode.OthersBuffered,g);
		}
		else if(PhotonNetwork.playerList.Length>4||d==1)
		{
		Application.LoadLevel("find1");
		}
	
		}
	
	[RPC]
	void loadl(int g)
	{
		Debug.Log("loadl");
		int g1=PhotonNetwork.player.ID;
		print(g +":rand and this:"+g1);
		if(g==g1)
		{
			
			//hide_net hn=new hide_net();	
			//Debug.Log("hide:"+nm);
				//	hn.un=un;
			//Debug.Log("hn.un:"+hn.un+" and un:"+un);
			Application.LoadLevel("hide1");
		//Debug.Log("hide:"+un);

			//networkView.RPC("setn",RPCMode.AllBuffered,un,1);
			check=1;
		}
		else 
		{
			//networkView.RPC("targetval",RPCMode.AllBuffered,obj);
			//find_net fn=new find_net();	
			//Debug.Log("fn.un:"+fn.un+" and un:"+un);
			//Debug.Log("find:"+nm);
			Application.LoadLevel("find1");
	//fn.un=un;
			//Debug.Log("find:"+un);
			//networkView.RPC("setn",RPCMode.AllBuffered,un,2);
		}
		
		
	}
	

	


	/*[RPC]
	void showobj(string ob)
	{
		obj=ob;
		Debug.Log ("rec "+ob+ " and " +obj);
		photonView.RPC("targetval",PhotonTargets.AllBuffered,ob);
		//networkView.RPC("targetval",RPCMode.AllBuffered,ob);
		//  GUI.Label(new Rect(100, 175, 100, 25), ob);
	}*/
	
	

	
	
	/*[RPC]
	void winners()
	{
	
		Debug.Log("list length:"+win.Count);
		for(int b=0;b<win.Count;b++)
			winn.text+="\n"+win[b]+" reached level2";
	}*/

	
	/*[RPC]
	void targetval(string ob)
	{
		tar=ob;
	}*/
	/* [RPC]
    void ReceiveInfoFromClient(string someInfo) {
		print ("rec "+ someInfo);
        _messageLog += someInfo + "\n";
GUI.Label(new Rect(100, 175, 100, 25), _messageLog);
    }
	
		
	[RPC]
    void SendInfoToServer(string msg){
		}*/


}
