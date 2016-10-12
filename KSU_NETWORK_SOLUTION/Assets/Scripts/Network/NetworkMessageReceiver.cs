using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
public class NetworkMessageReceiver : NetworkManager {


	void Start ()
	{
		RegisterHandler();
	}

	private void RegisterHandler()
	{
		if (NetworkConnectionManager.IsServer == false)
		{
			NetworkConnectionManager.Client.RegisterHandler(MessageType.Int_CHN, ReceiveIntMessage);
			NetworkConnectionManager.Client.RegisterHandler(MessageType.Float_CHN, ReceiveFloatMessage);
			NetworkConnectionManager.Client.RegisterHandler(MessageType.String_CHN, ReceiveStringMessage);
			NetworkConnectionManager.Client.RegisterHandler(MessageType.Bool_CHN, ReceiveBoolMessage);
			NetworkConnectionManager.Client.RegisterHandler(MessageType.Vector3_CHN, ReceiveVector3Message);

		}
		else
		{
			NetworkServer.RegisterHandler(MessageType.Int_CHN, ReceiveIntMessage);
			NetworkServer.RegisterHandler(MessageType.Float_CHN, ReceiveFloatMessage);
			NetworkServer.RegisterHandler(MessageType.String_CHN, ReceiveStringMessage);
			NetworkServer.RegisterHandler(MessageType.Bool_CHN, ReceiveBoolMessage);
			NetworkServer.RegisterHandler(MessageType.Vector3_CHN, ReceiveVector3Message);

		}
	}

	private void ReceiveIntMessage(NetworkMessage netMsg)
	{
		var msg = netMsg.ReadMessage <IntMessage>();
		if (GameController.TransitionScene == "GameScene")
		{

		}
		GameObject.FindGameObjectWithTag("Info/TextMessage").GetComponent<Text>().text = "" + msg.value;
	}

	private void ReceiveFloatMessage(NetworkMessage netMsg)
	{
		var msg = netMsg.ReadMessage <FloatMessage>();
		if (GameController.TransitionScene == "GameScene")
		{
			GameObject.FindGameObjectWithTag("Info/TextMessage").GetComponent<Text>().text = "" + msg.value;
		}
	}

	private void ReceiveStringMessage(NetworkMessage netMsg)
	{
		var msg = netMsg.ReadMessage <StringMessage>();
		if (GameController.TransitionScene == "GameScene")
		{
			GameObject.FindGameObjectWithTag("Info/TextMessage").GetComponent<Text>().text = "" + msg.value;
		}
		if (NetworkConnectionManager.IsServer)
		{
			NetworkMessageSender.Send(msg.value, netMsg.conn.connectionId);
		}
	}

	private void ReceiveBoolMessage(NetworkMessage netMsg)
	{
		var msg = netMsg.ReadMessage <BoolMessage>();
		if (GameController.TransitionScene == "GameScene")
		{
			GameObject.FindGameObjectWithTag("Info/TextMessage").GetComponent<Text>().text = "" + msg.value;
		}
	}

	private void ReceiveVector3Message(NetworkMessage netMsg)
	{
		var msg = netMsg.ReadMessage <Vector3Message>();
		GameObject.Find("TestCube(Clone)").transform.localScale = msg.value;

	}

}
