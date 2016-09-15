using UnityEngine;
using System.Collections;

public class GameNetworkManager : MonoBehaviour {

	public static GameNetworkManager Instance;
	void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
		} else {
			DontDestroyOnLoad(gameObject);
		}
	}

}
