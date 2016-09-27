using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.Networking.Types;
public class NetworkConnectionManager : NetworkManager {


	public static bool IsServer;
	public static bool IsClientConnected;
	public static NetworkClient Client;
	public static int ActiveConnections;
	public static string HostIPAddress;

	public void StartGameServer()
	{
		Debug.LogError("Server Started...");
		IsServer = true;
		StartServer();
		//StartMatchMaker();
		//CreateInternetMatch("TestMatch");
		SceneManager.LoadScene("GameScene");
		HostIPAddress = Network.player.ipAddress;
	}

	// public void CreateInternetMatch(string matchName)
	// {
	// 	CreateMatchRequest create = new CreateMatchRequest();
	// 	create.name = matchName;
	// 	create.size = 4;
	// 	create.advertise = true;
	// 	create.password = "";
	// 	NetworkManager.singleton.matchMaker.CreateMatch(create, OnInternetMatchCreate);
	// }

	// private void OnInternetMatchCreate(CreateMatchResponse matchResponse)
	// {
	// 	if (matchResponse != null && matchResponse.success)
	// 	{
	// 		Debug.Log("Create match succeeded");

	// 		MatchInfo hostInfo = new MatchInfo(matchResponse);
	// 		NetworkServer.Listen(hostInfo, 9000);

	// 		NetworkManager.singleton.StartHost(hostInfo);
	// 	}
	// 	else
	// 	{
	// 		Debug.LogError("Create match failed");
	// 	}
	// }

	public void ConnectClientToServer(string targetIP)
	{
		StartCoroutine("SetupClient", targetIP);
		//StartMatchMaker();
		//FindInternetMatch("TestMatch");
		Debug.LogError("Client is now connecting...");
	}



	// public void FindInternetMatch(string matchName)
	// {

	// 	NetworkManager.singleton.matchMaker.ListMatches(0, 20, matchName, OnInternetMatchList);
	// }

	// private void OnInternetMatchList(ListMatchResponse matchListResponse)
	// {
	// 	if (matchListResponse.success)
	// 	{
	// 		if (matchListResponse.matches.Count != 0)
	// 		{
	// 			Debug.Log("A list of matches was returned");

	// 			//join the last server (just in case there are two...)
	// 			NetworkManager.singleton.matchMaker.JoinMatch(matchListResponse.matches[matchListResponse.matches.Count - 1].networkId, "", OnJoinInternetMatch);
	// 		}
	// 		else
	// 		{
	// 			Debug.Log ("No matches in requested room!");
	// 		}
	// 	}
	// 	else
	// 	{
	// 		Debug.LogError("Couldn't connect to match maker");
	// 	}
	// }

	// private void OnJoinInternetMatch(JoinMatchResponse matchJoin)
	// {
	// 	if (matchJoin.success)
	// 	{
	// 		Debug.Log("Able to join a match");


	// 		MatchInfo hostInfo = new MatchInfo(matchJoin);
	// 		NetworkManager.singleton.StartClient(hostInfo);
	// 	}
	// 	else
	// 	{
	// 		Debug.LogError("Join match failed");
	// 	}
	// }

	private IEnumerator SetupClient(string targetIP)
	{
		StopClient();
		yield return new WaitForSeconds(1);
		networkAddress = targetIP;
		StartClient();
		Client = client;
	}

	public override void OnServerConnect(NetworkConnection conn)
	{
		base.OnServerConnect (conn);
		Debug.LogError ("A New client has connected to the server");
	}

	public override void OnClientConnect(NetworkConnection conn)
	{
		IsClientConnected = true;
		SceneManager.LoadScene("GameScene");
		ActiveConnections = numPlayers;
		Debug.LogError("Current Connections => " + Network.connections.Length);
		Debug.Log("Client has connected to the server...");
	}
}
