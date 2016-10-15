using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Networking;
/// <summary>
/// Class is Responsible to sending messages to the client
/// </summary>
public class NetworkMessageSender: NetworkManager
{
	/// <summary>
	/// Sends an int value
	/// </summary>
	/// <param name="intValue"></param>
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
	/// <summary>
	/// Sends a float value
	/// </summary>
	/// <param name="floatValue"></param>
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

	/// <summary>
	/// Sends a string value
	/// </summary>
	/// <param name="stringValue"></param>
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

	/// <summary>
	/// Sends a bool value
	/// </summary>
	/// <param name="boolValue"></param>
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

	/// <summary>
	/// Sends a Vector3 value
	/// </summary>
	/// <param name="vector3Value"></param>
	public static void Send(Vector3 vector3Value)
	{
		Vector3Message msg = new Vector3Message();
		msg.value = vector3Value;
		if (NetworkConnectionManager.IsServer)
		{
			NetworkServer.SendToAll(MessageType.Vector3_CHN, msg);
		} else
		{
			NetworkConnectionManager.Client.Send(MessageType.Vector3_CHN, msg);
		}
	}

	/// <summary>
	/// Sends Vector3 value that will effect object with specific netID
	/// </summary>
	/// <param name="vector3Value"></param>
	/// <param name="_netID"></param>
	/// <param name="_taskID"></param>
	public static void Send(Vector3 vector3Value, NetworkInstanceId _netID, TaskID _taskID)
	{
		Vector3Message msg = new Vector3Message();
		msg.value = vector3Value;
		msg.taskID = _taskID;
		msg.netID = _netID;
		if (NetworkConnectionManager.IsServer)
		{
			NetworkServer.SendToAll(MessageType.Vector3_CHN, msg);
		} else
		{
			NetworkConnectionManager.Client.Send(MessageType.Vector3_CHN, msg);
		}
	}

	/// <summary>
	/// Sends Vector3 value that will effect the object with specific netID to a specific client
	/// </summary>
	/// <param name="vector3Value"></param>
	/// <param name="_netID"></param>
	/// <param name="_taskID"></param>
	/// <param name="clientID"></param>
	public static void Send(Vector3 vector3Value, NetworkInstanceId _netID, TaskID _taskID, int clientID)
	{
		Vector3Message msg = new Vector3Message();
		msg.value = vector3Value;
		msg.taskID = _taskID;
		msg.netID = _netID;
		if (NetworkConnectionManager.IsServer)
		{
			NetworkServer.SendToClient(clientID, MessageType.Vector3_CHN, msg);
		}
	}

	/// <summary>
	/// Sends the string to all Clients besides the exception
	/// </summary>
	/// <param name="stringValue"></param>
	/// <param name="execption"></param>
	public static void Send(string stringValue, int execption)
	{
		StringMessage msg = new StringMessage();
		msg.value = stringValue;
		foreach (NetworkConnection n in NetworkServer.connections)
		{
			if (n == null || n.connectionId == execption)
			{
				continue;
			}
			NetworkServer.SendToClient(n.connectionId, MessageType.String_CHN, msg);
		}
	}

}

public class IntMessage: MessageBase {public int value; public  TaskID taskID;  public NetworkInstanceId netID;}
public class FloatMessage: MessageBase {public float value; public  TaskID taskID;  public NetworkInstanceId netID;}
public class StringMessage: MessageBase {public string value; public  TaskID taskID; public NetworkInstanceId netID; }
public class BoolMessage: MessageBase {public bool value; public  TaskID taskID;  public NetworkInstanceId netID;}
public class Vector3Message: MessageBase {public Vector3 value; public  TaskID taskID; public NetworkInstanceId netID; }

public class MessageType
{
	public const short Int_CHN = 1000;
	public const short Float_CHN = 1001;
	public const short Bool_CHN = 1002;
	public const short String_CHN = 1003;
	public const short Vector3_CHN = 1004;

}
