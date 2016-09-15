using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class NetworkMessageReceiver : NetworkManager {

	public GameController gameController;
	private NetworkClient _client;
	void Start ()
	{
		if (NetworkConnectionManager.IsServer == false)
		{
			gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();

			_client = gameController.networkConnectionManager.Client;
			Debug.Log(_client);
			if (_client != null)
			{
				_client.RegisterHandler(MessageType.SERVER_MSG, ReceiveMessage);
				Debug.Log("Called");
			}
		}

	}


	private void ReceiveMessage(NetworkMessage netMsg)
	{
		var msg = netMsg.ReadMessage<Message> ();
		Debug.LogError(msg.message);
	}


}
