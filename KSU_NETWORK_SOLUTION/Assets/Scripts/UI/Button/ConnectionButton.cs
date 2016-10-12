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
			gameController.networkConnectionManager.hostOption = HostOption.HOST;
			gameController.networkConnectionManager.netInstanceID = NetInstanceID.SERVER;
			gameController.networkConnectionManager.StartGameServer();
		}

		if (buttonID == ButtonID.HOST_AND_PLAY)
		{
			gameController.networkConnectionManager.hostOption = HostOption.HOST_AND_PLAY;
			gameController.networkConnectionManager.netInstanceID = NetInstanceID.SERVER_CLIENT;
			gameController.networkConnectionManager.StartGameServer();
		}

		if (buttonID == ButtonID.JOIN)
		{
			gameController.networkConnectionManager.ConnectClientToServer("");
			gameController.networkConnectionManager.netInstanceID = NetInstanceID.CLIENT;
		}
	}
}
