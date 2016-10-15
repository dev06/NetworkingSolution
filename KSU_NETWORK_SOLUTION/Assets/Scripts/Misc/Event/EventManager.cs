using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	public delegate void ClientConnect();
	public static ClientConnect OnClientConnect;
}
