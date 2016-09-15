using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ButtonEventHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

	public Color HoverColor;
	public Color RestColor;


	protected Image _image;

	void Start () {
		Init();
	}

	void Init()
	{
		_image = GetComponent<Image>();
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
