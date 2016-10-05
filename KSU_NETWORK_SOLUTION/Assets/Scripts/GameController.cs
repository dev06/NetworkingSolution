using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public static GameController Instance;
	public static string TransitionScene = "DemoScene";

	public NetworkConnectionManager networkConnectionManager;
	public NetworkSpawnManager networkSpawnManager;
	public OverridenNetworkDiscovery overridenNetworkDiscovery;

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
		//networkSpawnManager = GameObject.FindWithTag("NetworkManager/NetworkSpawnManager").GetComponent<NetworkSpawnManager>();

		overridenNetworkDiscovery = GetComponent<OverridenNetworkDiscovery>();
	}
}

public enum HostOption
{
	HOST_AND_PLAY,
	HOST,
}



