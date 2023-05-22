using UnityEngine;
using System.Collections;

public class CoinVisibility : MonoBehaviour {

	void OnBecameInvisible()
	{
		Debug.Log("SAKRIO, OPAAAAA");
		renderer.enabled = false;
	}

	void OnBecameVisible()
	{
		if(MonkeyController2D.canRespawnThings)
		{
			Debug.Log("SAD SE VIDI, RNZAAAA");
			renderer.enabled = true;
		}
	}
}
