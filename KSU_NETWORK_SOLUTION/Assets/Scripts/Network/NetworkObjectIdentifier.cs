using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class NetworkObjectIdentifier : NetworkBehaviour {

	GameController _gameController;
	NetworkConnectionManager _networkConnectionManager;


	public NetworkInstanceId netID;

	private Vector3 _lastScale;
	private Vector3 _lastPosition;
	private Vector3 _lastRotation;

	private float frameCount;

	void Start()
	{
		_lastScale = transform.localScale;
		_lastRotation = transform.eulerAngles;
		_lastPosition = transform.position;
		netID = GetComponent<NetworkIdentity>().netId;
	}


	void Update()
	{
		frameCount++;
		if (NetworkConnectionManager.IsServer)
		{
			if (frameCount % NetworkConnectionManager.MessageSendRate == 0)
			{
				SendTransform(true);
				frameCount = 0;
			}
		}
	}

	public void SendTransform(bool _safety)
	{
		if (_safety)
		{
			if (_lastScale != transform.localScale)
			{
				NetworkMessageSender.Send(transform.localScale, netID, TaskID.Scale);
				_lastScale = transform.localScale;
			}

			if (_lastRotation != transform.rotation.eulerAngles)
			{
				NetworkMessageSender.Send(transform.rotation.eulerAngles, netID, TaskID.Rotation);
				_lastRotation = transform.rotation.eulerAngles;
			}

			if (_lastPosition != transform.position)
			{
				NetworkMessageSender.Send(transform.position, netID, TaskID.Position);
				_lastPosition = transform.position;
			}
		} else {
			NetworkMessageSender.Send(transform.localScale, netID, TaskID.Scale);
			_lastScale = transform.localScale;
			NetworkMessageSender.Send(transform.rotation.eulerAngles, netID, TaskID.Rotation);
			_lastRotation = transform.rotation.eulerAngles;
			NetworkMessageSender.Send(transform.position, netID, TaskID.Position);
			_lastPosition = transform.position;
		}
	}

	public void SendTransform(bool _safety, int _clientID)
	{
		if (_safety)
		{
			if (_lastScale != transform.localScale)
			{
				NetworkMessageSender.Send(transform.localScale, netID, TaskID.Scale, _clientID);
				_lastScale = transform.localScale;
			}

			if (_lastRotation != transform.rotation.eulerAngles)
			{
				NetworkMessageSender.Send(transform.rotation.eulerAngles, netID, TaskID.Rotation, _clientID);
				_lastRotation = transform.rotation.eulerAngles;
			}

			if (_lastPosition != transform.position)
			{
				NetworkMessageSender.Send(transform.position, netID, TaskID.Position, _clientID);
				_lastPosition = transform.position;
			}
		} else {
			NetworkMessageSender.Send(transform.localScale, netID, TaskID.Scale, _clientID);
			_lastScale = transform.localScale;
			NetworkMessageSender.Send(transform.rotation.eulerAngles, netID, TaskID.Rotation, _clientID);
			_lastRotation = transform.rotation.eulerAngles;
			NetworkMessageSender.Send(transform.position, netID, TaskID.Position, _clientID);
			_lastPosition = transform.position;
		}
	}
}
