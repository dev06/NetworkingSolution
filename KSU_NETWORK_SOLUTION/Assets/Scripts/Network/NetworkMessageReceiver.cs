using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
public class NetworkMessageReceiver : NetworkManager {


	void Start ()
	{
		RegisterHandler();
	}
	/// <summary>
	/// Registers the Handler for Server and Client
	/// </summary>
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

	/// <summary>
	/// Receives an Int Message
	/// </summary>
	/// <param name="netMsg"></param>
	private void ReceiveIntMessage(NetworkMessage netMsg)
	{
		var msg = netMsg.ReadMessage <IntMessage>();
		if (GameController.TransitionScene == "GameScene")
		{
			GameObject.FindGameObjectWithTag("Info/TextMessage").GetComponent<Text>().text = "" + msg.value;
		}
	}

	/// <summary>
	/// Receives a Float Message
	/// </summary>
	/// <param name="netMsg"></param>
	private void ReceiveFloatMessage(NetworkMessage netMsg)
	{
		var msg = netMsg.ReadMessage <FloatMessage>();
		if (GameController.TransitionScene == "GameScene")
		{
			GameObject.FindGameObjectWithTag("Info/TextMessage").GetComponent<Text>().text = "" + msg.value;
		}
	}

	/// <summary>
	/// Recieves a String Message
	/// </summary>
	/// <param name="netMsg"></param>
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

	/// <summary>
	/// Receives a bool Message
	/// </summary>
	/// <param name="netMsg"></param>
	private void ReceiveBoolMessage(NetworkMessage netMsg)
	{
		var msg = netMsg.ReadMessage <BoolMessage>();
		if (GameController.TransitionScene == "GameScene")
		{
			GameObject.FindGameObjectWithTag("Info/TextMessage").GetComponent<Text>().text = "" + msg.value;
		}
	}

	/// <summary>
	/// Receives a Vector3 Message
	/// </summary>
	/// <param name="netMsg"></param>
	private void ReceiveVector3Message(NetworkMessage netMsg)
	{
		var msg = netMsg.ReadMessage <Vector3Message>();

		if (msg.netID != null)
		{
			GameObject _object = ClientScene.FindLocalObject(msg.netID);
			if (_object != null)
			{
				_object.GetComponent<NetworkTransform>().HandleTransformMessage(_object, msg.value, msg.taskID);
			}
		}

	}

}
