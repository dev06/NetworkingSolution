using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameSceneController : MonoBehaviour {

	private GameController _gameController;
	private Text _activeConnectionsText;
	void Start ()
	{
		Init();

	}

	void Init()
	{
		_gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
		_activeConnectionsText = GameObject.FindWithTag("Info/Connections").GetComponent<Text>();
		if (NetworkConnectionManager.IsServer)
		{
			GameObject.FindWithTag("Info/Status").GetComponent<Text>().text = "Status : HOST ";
			GameObject.FindWithTag("Info/IP").GetComponent<Text>().text = "IP : " + NetworkConnectionManager.HostIPAddress;
			GameObject.FindWithTag("Info/Connections").GetComponent<Text>().text = "Connections: " + NetworkConnectionManager.ActiveConnections;

		}
		else {
			GameObject.FindWithTag("Info/Status").GetComponent<Text>().text = "Status : CLIENT ";
			//GameObject.FindWithTag("Info/IP").GetComponent<Text>().text = "Connected IP : " + NetworkConnectionManager.Client.serverIp;
			GameObject.FindWithTag("Info/Connections").GetComponent<Text>().text = "Connections: " + NetworkConnectionManager.ActiveConnections;
		}

	}


	void Update ()
	{
		_activeConnectionsText.text = "Connections: " + NetworkConnectionManager.ActiveConnections;
	}
}
