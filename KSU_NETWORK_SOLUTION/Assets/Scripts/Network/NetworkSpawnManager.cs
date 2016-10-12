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
		Debug.LogError(_networkConnectionManager.netInstanceID);
		if (_networkConnectionManager.netInstanceID == NetInstanceID.SERVER_CLIENT)
		{

			Debug.Log("Spawn Manager Started");
			StartCoroutine("SpawnObjectsOnServer");
		} else
		{
			StartCoroutine("SpawnObjectsOnClient");
		}
	}

	public void RegisterPrefab()
	{
		ClientScene.RegisterPrefab(Instantiate((GameObject)Resources.Load("Prefabs/TestCube")));
	}

	void Update()
	{
		// if (Input.GetKeyDown(KeyCode.Q))
		// {
		// 	GameObject go = (GameObject)Instantiate(Resources.Load("Prefabs/TestCube"), new Vector3(Random.Range(-3, 3), 2, Random.Range(-3, 3)), Quaternion.identity);
		// 	NetworkServer.Spawn(go);
		// }
	}

	private IEnumerator SpawnObjectsOnServer()
	{
		yield return new WaitForSeconds(1.0F);
		NetworkServer.Spawn(Instantiate((GameObject)Resources.Load("Prefabs/TestCube")));

	}
	private IEnumerator SpawnObjectsOnClient()
	{
		yield return new WaitForSeconds(1.0F);
		RegisterPrefab();

	}

}
