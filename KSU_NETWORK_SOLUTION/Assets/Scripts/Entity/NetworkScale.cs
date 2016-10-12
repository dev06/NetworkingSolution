using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class NetworkScale : NetworkBehaviour {

	GameController _gameController;
	NetworkConnectionManager _networkConnectionManager;

	public string assetID;

	private Vector3 _lastScale;
	void Start()
	{
		_lastScale = transform.localScale;
		assetID = GetComponent<NetworkIdentity>().assetId + "";
	}


	void Update()
	{
		if (NetworkConnectionManager.IsServer)
		{
			if (_lastScale != transform.localScale)
			{
				NetworkMessageSender.Send(transform.localScale, assetID);
				_lastScale = transform.localScale;
			}
		}
	}
}
