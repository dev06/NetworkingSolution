using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public static GameController Instance;

	public NetworkConnectionManager networkConnectionManager;
	public OverridenNetworkDiscovery overridenNetworkDiscovery;

	void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
		} else {
			DontDestroyOnLoad(gameObject);
		}
		Init();
	}

	private void Init()
	{
		networkConnectionManager = GameObject.FindWithTag("NetworkManager/NetworkConnectionManager").GetComponent<NetworkConnectionManager>();
		overridenNetworkDiscovery = GetComponent<OverridenNetworkDiscovery>();
	}
}



