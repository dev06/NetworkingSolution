using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
public class OverridenNetworkDiscovery : NetworkDiscovery {

	GameController _gameController;
	void Start()
	{
		_gameController = GetComponent<GameController>();
	}

	public void StartGameServer()
	{
		Initialize();
		StartAsServer();
	}

	public void StartGameClient()
	{
		Initialize();
		StartAsClient();
		Debug.Log("Client has started");
	}

	public override void OnReceivedBroadcast (string fromAddress, string data)
	{
		base.OnReceivedBroadcast(fromAddress, data);
		NetworkConnectionManager.HostIPAddress = fromAddress;
		Debug.Log("BroadCast Recieved -> " + fromAddress + " " + data);
		if (_gameController.networkConnectionManager != null)
		{
			_gameController.networkConnectionManager.ConnectClientToServer(fromAddress);

			StartCoroutine("StopListeningToBroadCast");
		}
	}

	public IEnumerator StopListeningToBroadCast()
	{
		yield return new WaitForSeconds(2);
		if (NetworkConnectionManager.IsClientConnected)
		{
			StopBroadcast();
		}
	}
}
