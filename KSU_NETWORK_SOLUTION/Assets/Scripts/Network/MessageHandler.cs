using UnityEngine;
using System.Collections;
/// <summary>
/// Class used for handling recieved messages.
/// </summary>
public class MessageHandler : MonoBehaviour {


	public enum TaskID
	{
		Manage_Transform,
	}
	private GameController _gameController;

	void Start ()
	{
		_gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
	}
}
