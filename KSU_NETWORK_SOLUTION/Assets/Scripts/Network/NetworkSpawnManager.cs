using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class NetworkSpawnManager : MonoBehaviour {

	// Use this for initialization\
	private GameController _gameController;
	private NetworkConnectionManager _networkConnectionManager;
	void Start ()
	{
		_gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
		_networkConnectionManager = _gameController.networkConnectionManager;
	}



	public void StartSpawnManager()
	{
		Debug.Log(_networkConnectionManager.netInstanceID);
		if (_networkConnectionManager.netInstanceID == NetInstanceID.SERVER_CLIENT)
		{
			Debug.Log("Spawn Manager Started");
			//NetworkServer.Spawn(Instantiate((GameObject)Resources.Load("Prefabs/TestCube")));
		} else
		{
			//	RegisterPrefab();
		}
	}

	public void RegisterPrefab()
	{
		ClientScene.RegisterPrefab(Instantiate((GameObject)Resources.Load("Prefabs/TestCube")));
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			NetworkServer.Spawn(Instantiate((GameObject)Resources.Load("Prefabs/TestCube")));
		}
	}
}
