using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Networking;
public class NetworkMessageSender: NetworkManager
{


	public static void Send(int intValue)
	{
		IntMessage msg = new IntMessage();
		msg.value = intValue;
		if (NetworkConnectionManager.IsServer)
		{
			NetworkServer.SendToAll(MessageType.Int_CHN, msg);
		} else
		{
			NetworkConnectionManager.Client.Send(MessageType.Int_CHN, msg);
		}
	}

	public static void Send(float floatValue)
	{
		FloatMessage msg = new FloatMessage();
		msg.value = floatValue;
		if (NetworkConnectionManager.IsServer)
		{
			NetworkServer.SendToAll(MessageType.Float_CHN, msg);
		} else
		{
			NetworkConnectionManager.Client.Send(MessageType.Float_CHN, msg);
		}
	}

	public static void Send(string stringValue)
	{
		StringMessage msg = new StringMessage();
		msg.value = stringValue;
		if (NetworkConnectionManager.IsServer)
		{
			NetworkServer.SendToAll(MessageType.String_CHN, msg);
		} else
		{
			NetworkConnectionManager.Client.Send(MessageType.String_CHN, msg);
		}
	}

	public static void Send(bool boolValue)
	{
		BoolMessage msg = new BoolMessage();
		msg.value = boolValue;
		if (NetworkConnectionManager.IsServer)
		{
			NetworkServer.SendToAll(MessageType.Bool_CHN, msg);
		} else
		{
			NetworkConnectionManager.Client.Send(MessageType.Bool_CHN, msg);
		}
	}



}

public class IntMessage: MessageBase {public int value; }
public class FloatMessage: MessageBase {public float value; }
public class StringMessage: MessageBase {public string value; }
public class BoolMessage: MessageBase {public bool value; }

public class MessageType
{
	public const short Int_CHN = 1000;
	public const short Float_CHN = 1001;
	public const short Bool_CHN = 1002;
	public const short String_CHN = 1003;
}
