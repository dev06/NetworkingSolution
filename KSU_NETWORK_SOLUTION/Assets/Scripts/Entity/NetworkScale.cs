using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class NetworkScale : NetworkBehaviour {

	GameController _gameController;
	NetworkConnectionManager _networkConnectionManager;

	[SyncVar]
	public Vector3 scale;

	[SerializeField] Transform myScale;
	private void Start()
	{
		_gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
		_networkConnectionManager = _gameController.networkConnectionManager;
		myScale = transform;
	}

	void FixedUpdate()
	{
		TransmitScale();
		if (!isLocalPlayer)
		{
			myScale.localScale = transform.localScale;
		}
	}

	[Command]
	void CmdProvideScaleToServer(Vector3 _scale)
	{
		scale = _scale;

	}

	[ClientCallback	]
	void TransmitScale()
	{
		if (isLocalPlayer)
		{
			CmdProvideScaleToServer(myScale.localScale);
		}
	}
}
