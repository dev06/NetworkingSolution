using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update ()
	{
		if (GameObject.Find("TestCube(Clone)") != null)
		{
			GetComponent<Text>().text = GameObject.Find("TestCube(Clone)").GetComponent<NetworkIdentity>().assetId + "";
		}
	}
}
