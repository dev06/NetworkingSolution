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
		NetworkConnectionManager.HostIPAddress = fromAddress;
		Debug.Log("BroadCast Recieved -> " + fromAddress + " " + data);
		if (_gameController.networkConnectionManager != null)
		{
			if (NetworkConnectionManager.IsClientConnected ==  false)
			{
				if (NetworkConnectionManager.IsConnecting == false)
				{
					_gameController.networkConnectionManager.ConnectClientToServer(fromAddress);
					NetworkConnectionManager.IsConnecting = true;
				}
			}
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
