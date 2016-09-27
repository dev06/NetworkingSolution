﻿using UnityEngine;
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
		}
		else
		{
			NetworkServer.RegisterHandler(MessageType.Int_CHN, ReceiveIntMessage);
			NetworkServer.RegisterHandler(MessageType.Float_CHN, ReceiveFloatMessage);
			NetworkServer.RegisterHandler(MessageType.String_CHN, ReceiveStringMessage);
			NetworkServer.RegisterHandler(MessageType.Bool_CHN, ReceiveBoolMessage);
		}
	}

	private void ReceiveIntMessage(NetworkMessage netMsg)
	{
		var msg = netMsg.ReadMessage <IntMessage>();
		GameObject.FindGameObjectWithTag("Info/TextMessage").GetComponent<Text>().text = "" + msg.value;
	}

	private void ReceiveFloatMessage(NetworkMessage netMsg)
	{
		var msg = netMsg.ReadMessage <FloatMessage>();
		GameObject.FindGameObjectWithTag("Info/TextMessage").GetComponent<Text>().text = "" + msg.value;
	}

	private void ReceiveStringMessage(NetworkMessage netMsg)
	{
		var msg = netMsg.ReadMessage <StringMessage>();
		GameObject.FindGameObjectWithTag("Info/TextMessage").GetComponent<Text>().text = "" + msg.value;
	}

	private void ReceiveBoolMessage(NetworkMessage netMsg)
	{
		var msg = netMsg.ReadMessage <BoolMessage>();
		GameObject.FindGameObjectWithTag("Info/TextMessage").GetComponent<Text>().text = "" + msg.value;
	}

}
