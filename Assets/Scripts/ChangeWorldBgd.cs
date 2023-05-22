using UnityEngine;
using System.Collections;

public class ChangeWorldBgd : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void ChangeBgd()
	{
		Camera.main.transform.Find("Background").renderer.material = GameObject.Find("TempBgd").renderer.material;
	}
}
