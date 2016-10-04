﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.Networking.Types;
public class NetworkConnectionManager : NetworkManager {


	public static bool IsServer;
	public static bool IsClientConnected;
	public static bool IsConnecting;
	public static NetworkClient Client;
	public static int ActiveConnections;
	public static string HostIPAddress;


	private GameController _gameController;
	private NetworkSpawnManager _networkSpawnManager;


	void Start()
	{
		_gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
		//_networkSpawnManager = _gameController.networkSpawnManager;
	}


	public void StartGameServer()
	{
		// Debug.LogError("Server Started...");
		SceneManager.LoadScene(GameController.TransitionScene);
		StartMatchMaker();
		CreateInternetMatch("TestMatch");
		IsServer = true;
		HostIPAddress = Network.player.ipAddress;
	}



	public void ConnectClientToServer(string targetIP)
	{

		StartMatchMaker();
		FindInternetMatch("TestMatch");
		Debug.LogError("Client is now connecting...");
	}

	public void CreateInternetMatch(string matchName)
	{
		CreateMatchRequest create = new CreateMatchRequest();
		create.name = matchName;
		create.size = 4;
		create.advertise = true;
		create.password = "";

		matchMaker.CreateMatch(create, OnInternetMatchCreate);

	}

	private void OnInternetMatchCreate(CreateMatchResponse matchResponse)
	{
		if (matchResponse != null && matchResponse.success)
		{
			Debug.Log("Create match succeeded");

			MatchInfo hostInfo = new MatchInfo(matchResponse);
			NetworkServer.Listen(hostInfo, 9000);

			StartHost(hostInfo);

		}
		else
		{
			Debug.LogError("Create match failed");
		}
	}

	// // private IEnumerator Spawn()
	// // {
	// // 	yield return new WaitForSeconds(1.0f);
	// // }

	public void FindInternetMatch(string matchName)
	{
		matchMaker.ListMatches(0, 20, matchName, OnInternetMatchList);
	}

	private void OnInternetMatchList(ListMatchResponse matchListResponse)
	{
		if (matchListResponse.success)
		{
			if (matchListResponse.matches.Count != 0)
			{
				Debug.Log("A list of matches was returned");

				//join the last server (just in case there are two...)
				matchMaker.JoinMatch(matchListResponse.matches[matchListResponse.matches.Count - 1].networkId, "", OnJoinInternetMatch);
			}
			else
			{
				Debug.Log ("No matches in requested room!");
			}
		}
		else
		{
			Debug.LogError("Couldn't connect to match maker");
		}
	}

	// //this method is called when your request to join a match is returned
	private void OnJoinInternetMatch(JoinMatchResponse matchJoin)
	{
		if (matchJoin.success)
		{
			Debug.Log("Able to join a match");
			SceneManager.LoadScene(GameController.TransitionScene);
			MatchInfo hostInfo = new MatchInfo(matchJoin);
			StartClient(hostInfo);
			Client = client;

		}
		else
		{
			Debug.LogError("Join match failed");
		}
	}

	public override void OnServerConnect(NetworkConnection conn)
	{
		base.OnServerConnect (conn);


	}

	public override void OnServerDisconnect(NetworkConnection conn)
	{
		base.OnServerConnect (conn);
	}

	public override void OnClientConnect(NetworkConnection conn)
	{
		IsClientConnected = true;

		ActiveConnections = numPlayers;
		IsConnecting = false;
	}



	public override void OnClientDisconnect(NetworkConnection conn)
	{
		IsClientConnected = false;
		SceneManager.LoadScene("ConnectScene");
		IsConnecting = false;
	}


	public int GetCurrentConnections()
	{
		int _connections = 0;
		foreach (NetworkConnection n in NetworkServer.connections)
		{
			if (n == null)
			{
				continue;
			}
			_connections++;
		}

		return ActiveConnections = _connections;

	}

}
