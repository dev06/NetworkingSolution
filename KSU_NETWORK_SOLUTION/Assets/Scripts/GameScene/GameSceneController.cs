using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameSceneController : MonoBehaviour {

	private GameController _gameController;
	void Start ()
	{
		Init();

	}

	void Init()
	{
		_gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
		if (NetworkConnectionManager.IsServer)
		{
			GameObject.FindWithTag("Info/Status").GetComponent<Text>().text = "Status : HOST ";
			GameObject.FindWithTag("Info/IP").GetComponent<Text>().text = "IP : " + NetworkConnectionManager.HostIPAddress;
		}
		else {
			GameObject.FindWithTag("Info/Status").GetComponent<Text>().text = "Status : CLIENT ";
			GameObject.FindWithTag("Info/IP").GetComponent<Text>().text = "Connected IP : " + NetworkConnectionManager.Client.serverIp;

		}

	}


	void Update ()
	{

	}
}
