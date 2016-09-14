using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class GameNetworkManager : NetworkManager   {

	void Start ()
	{
		StartServer();
	}

	void Update ()
	{

	}

	public void OnClientConnect(NetworkConnection conn)
	{
		Debug.Log(conn);
	}



}
