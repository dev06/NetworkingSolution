using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public static GameController Instance;
	public static string TransitionScene = "DemoScene";

	public NetworkConnectionManager networkConnectionManager;
	public NetworkSpawnManager networkSpawnManager;
	public OverridenNetworkDiscovery overridenNetworkDiscovery;
	public MessageHandler messageHandler;

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

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			if (NetworkConnectionManager.IsServer)
			{
				NetworkSpawnManager.Spawn(AppResources.TestCube, Vector3.right * Random.Range(-10f, 10f) + Vector3.forward * Random.Range(-10f, 10f), Quaternion.identity);
			}
		}
	}


	private void Init()
	{
		networkConnectionManager = GameObject.FindWithTag("NetworkManager/NetworkConnectionManager").GetComponent<NetworkConnectionManager>();
		messageHandler = GameObject.FindWithTag("Handler/MessageHandler").GetComponent<MessageHandler>();
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



