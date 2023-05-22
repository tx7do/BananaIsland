using UnityEngine;
using System.Collections;

[RequireComponent (typeof(TextMesh))]
public class FadeText : MonoBehaviour {

	TextMesh tm;
	void Start () 
	{
		tm = GetComponent<TextMesh>();
	}
	
	void Update () 
	{
		if(Input.GetKeyUp(KeyCode.Q))
		{
			StartCoroutine(FadeOut(0.005f));
		}
	}

	IEnumerator FadeOut(float step)
	{
		float t = 0;
		while(t < 1)
		{
			tm.renderer.material.color = new Color(tm.renderer.material.color.r,tm.renderer.material.color.g,tm.renderer.material.color.b,Mathf.Lerp(1,0,t));
			t+=step;
			yield return null;
		}
	}
}
