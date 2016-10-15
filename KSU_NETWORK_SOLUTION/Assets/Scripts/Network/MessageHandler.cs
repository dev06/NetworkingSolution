using UnityEngine;
using System.Collections;
/// <summary>
/// Class used for handling recieved messages.
/// </summary>
public class MessageHandler : MonoBehaviour {


	private GameController _gameController;


	void Start ()
	{
		_gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
	}







}


/// <summary>
/// Task IDs allows the Network message receiver to know which values to change.
/// </summary>
public enum TaskID
{
	Position,
	Rotation,
	Scale,
}
