using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ButtonEventHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

	public GameController gameController;
	public Color HoverColor;
	public Color RestColor;
	public ButtonID buttonID;

	protected Image _image;

	void Start () {
		Init();
	}

	protected void Init()
	{
		_image = GetComponent<Image>();
		gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
	}

	void Update () {

	}


	public virtual void OnPointerEnter(PointerEventData data)
	{
		if (_image != null)
		{
			_image.color = HoverColor;
		}
	}

	public virtual void OnPointerExit(PointerEventData data)
	{
		if (_image != null)
		{
			_image.color = RestColor;
		}
	}

	public virtual void OnPointerClick(PointerEventData data)
	{

	}

}
