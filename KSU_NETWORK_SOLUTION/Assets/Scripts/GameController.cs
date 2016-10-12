﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public static GameController Instance;
	public static string TransitionScene = "DemoScene";

	public NetworkConnectionManager networkConnectionManager;
	public NetworkSpawnManager networkSpawnManager;
	public OverridenNetworkDiscovery overridenNetworkDiscovery;
	public MessageHandler messagleHandler;

	void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
		} else {
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		Init();
	}


	private void Init()
	{
		networkConnectionManager = GameObject.FindWithTag("NetworkManager/NetworkConnectionManager").GetComponent<NetworkConnectionManager>();
		messagleHandler = GameObject.FindWithTag("Handler/MessageHandler").GetComponent<MessageHandler>();
		overridenNetworkDiscovery = GetComponent<OverridenNetworkDiscovery>();
	}
}

public enum HostOption
{
	HOST_AND_PLAY,
	HOST,
}

public enum NetInstanceID
{
	SERVER,
	SERVER_CLIENT,
	CLIENT,
}



