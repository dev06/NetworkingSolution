using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
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
			string message = GameObject.FindWithTag("UI/MessageInput").transform.FindChild("Text").GetComponent<Text>().text;
			NetworkMessageSender.Send(message);
		}
	}
}
