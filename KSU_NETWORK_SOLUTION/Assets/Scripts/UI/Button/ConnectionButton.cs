using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
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
			//gameController.overridenNetworkDiscovery.StartGameServer();

		}

		if (buttonID == ButtonID.JOIN)
		{
			gameController.networkConnectionManager.ConnectClientToServer("");
		}
	}
}
