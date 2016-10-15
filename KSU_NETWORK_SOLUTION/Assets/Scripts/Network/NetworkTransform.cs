using UnityEngine;
public class NetworkTransform : MonoBehaviour
{

	private GameObject _object;
	private Vector3 _objectScale;
	private Vector3 _objectRotation;
	private Vector3 _objectPosition;

	void Start()
	{
		_objectScale  = transform.localScale;
		_objectRotation = transform.eulerAngles;
		_objectPosition = transform.position;
	}

	void Update()
	{
		if (_object  != null)
		{
			_object.transform.localScale = Vector3.Lerp(_object.transform.localScale, _objectScale, Time.deltaTime * 10);
			_object.transform.rotation = Quaternion.Lerp(_object.transform.rotation, Quaternion.Euler(_objectRotation), Time.deltaTime * 10);
			_object.transform.position = Vector3.Lerp(_object.transform.position, _objectPosition, Time.deltaTime * 10);
		}
	}

	public void HandleTransformMessage(GameObject _object, Vector3 _value , TaskID _taskID)
	{
		if (_taskID == TaskID.Scale)
		{
			this._object = _object;
			_objectScale = _value;
		}
		if (_taskID == TaskID.Position)
		{
			this._object = _object;
			_objectPosition = _value;
		}
		if (_taskID == TaskID.Rotation)
		{
			this._object = _object;
			_objectRotation = _value;
		}
	}
}