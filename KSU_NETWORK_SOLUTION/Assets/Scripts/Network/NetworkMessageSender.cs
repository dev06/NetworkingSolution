using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class NetworkMessageSender : NetworkManager
{
	public static void Send(string _message)
	{
		Message msg = new Message();
		msg.message = _message;
		NetworkServer.SendToAll(MessageType.SERVER_MSG, msg);
	}
}

public class Message: MessageBase
{
	public string message;
}


public class MessageType
{
	public const short SERVER_MSG = 1000;
}
