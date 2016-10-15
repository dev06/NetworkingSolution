using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class NetworkSpawnManager : MonoBehaviour {

	private NetworkConnectionManager _networkConnectionManager;

	void Start ()
	{
		_networkConnectionManager = GameController.Instance.networkConnectionManager;
	}

	/// <summary>
	/// Start the spawn Manager
	/// </summary>
	public void StartSpawnManager()
	{
		if (_networkConnectionManager.netInstanceID == NetInstanceID.CLIENT)
		{
			StartCoroutine("InitClientSpawnManager");
		}
		else
		{
			StartCoroutine("InitServerSpawnManager");
		}
	}

	/// <summary>
	/// Registers a given prefab
	/// </summary>
	/// <param name="_object"></param>
	public void RegisterPrefab(GameObject _object)
	{
		ClientScene.RegisterPrefab(_object);
	}

	/// <summary>
	/// Inits the Server Spawn Manager
	/// </summary>
	private IEnumerator InitServerSpawnManager()
	{
		yield return new WaitForSeconds(1.0F);
	}
	/// <summary>
	/// Inits the Client Spawn Manager
	/// </summary>

	private IEnumerator InitClientSpawnManager()
	{
		yield return new WaitForSeconds(1.0F);
		RegisterPrefab((GameObject)Resources.Load("Prefabs/TestCube"));
	}

	public static void Spawn(GameObject _object, Vector3 _position, Quaternion _rotation)
	{
		GameObject _go = (GameObject)Instantiate(_object, _position, _rotation);
		NetworkServer.Spawn(_go);
	}

	public static void Spawn(GameObject _object, Vector3 _position, Quaternion _rotation, Vector3 _scale)
	{
		GameObject _go = (GameObject)Instantiate(_object, _position, _rotation);
		_go.transform.localScale = _scale;
		NetworkServer.Spawn(_go);
	}


}
