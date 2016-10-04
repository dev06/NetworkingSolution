using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class NetworkSpawnManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{

	}



	public void StartSpawnManager()
	{
		//GetComponent<NetworkManager>().StartHost();
		//NetworkServer.Spawn(Instantiate((GameObject)Resources.Load("Prefabs/TestCube")));
	}

	public void RegisterPrefab()
	{
		ClientScene.RegisterPrefab((GameObject)Resources.Load("Prefabs/TestCube"));
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			NetworkServer.Spawn(Instantiate((GameObject)Resources.Load("Prefabs/TestCube")));
		}
	}
}
