using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
public class NetworkConnectionManager : NetworkManager {


	public static bool IsServer;
	public static bool IsClientConnected;

	public void StartGameServer()
	{
		Debug.Log("Server Started...");
		IsServer = true;
		StartServer();
		SceneManager.LoadScene("GameScene");
	}

	public void ConnectClientToServer()
	{
		StartCoroutine("SetupClient");
		Debug.Log("Client is now connecting...");
	}

	private IEnumerator SetupClient()
	{
		StopClient();
		yield return new WaitForSeconds(1);
		networkAddress = "127.0.0.1";
		StartClient();
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
		Debug.Log("Client has connected to the server...");
	}
}
