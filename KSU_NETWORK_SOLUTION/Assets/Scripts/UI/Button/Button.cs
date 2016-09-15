using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class Button : ButtonEventHandler {

	void Start ()
	{
		Init();
	}

	void Update () {

	}

	public override void OnPointerClick(PointerEventData data)
	{
		base.OnPointerClick(data);
		if (buttonID == ButtonID.SEND)
		{
			//SEND MESSAGE
			NetworkMessageSender.Send("Hello!");
			Debug.Log("Message Sent!");
		}
	}
}
