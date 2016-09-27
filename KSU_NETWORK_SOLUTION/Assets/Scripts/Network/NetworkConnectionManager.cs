using UnityEngine;
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

	public void StartGameServer()
	{
		Debug.LogError("Server Started...");
		IsServer = true;
		StartServer();
		SceneManager.LoadScene("GameScene");
		HostIPAddress = Network.player.ipAddress;
	}



	public void ConnectClientToServer(string targetIP)
	{
		StartCoroutine("SetupClient", targetIP);
		Debug.LogError("Client is now connecting...");
	}


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
		Debug.LogError (conn.connectionId + " A New client has connected to the server " + GetCurrentConnections());
	}

	public override void OnServerDisconnect(NetworkConnection conn)
	{
		base.OnServerConnect (conn);
		Debug.LogError (conn.connectionId + " has disconnected to the server " +  GetCurrentConnections());
	}

	public override void OnClientConnect(NetworkConnection conn)
	{
		IsClientConnected = true;
		SceneManager.LoadScene("GameScene");
		ActiveConnections = numPlayers;
		Debug.Log("This client has connected to the server...");
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
