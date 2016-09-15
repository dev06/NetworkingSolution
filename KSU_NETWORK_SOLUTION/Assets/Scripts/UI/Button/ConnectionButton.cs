using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class ConnectionButton : ButtonEventHandler {


	void Start ()
	{
		Init();
	}

	public override void OnPointerClick(PointerEventData data)
	{
		base.OnPointerClick(data);
		if (buttonID == ButtonID.HOST)
		{
			gameController.networkConnectionManager.StartGameServer();
		}

		if (buttonID == ButtonID.JOIN)
		{
			gameController.networkConnectionManager.ConnectClientToServer();
		}
	}
}
