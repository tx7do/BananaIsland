using UnityEngine;
using System.Collections;

public class MushroomAnimationEvents : MonoBehaviour {

	MonkeyController2D playerController;

	void Start ()
	{
		playerController = GameObject.FindGameObjectWithTag("Monkey").GetComponent<MonkeyController2D>();
	}

	void ReturnFromMushroom()
	{
		playerController.rigidbody2D.isKinematic = false;
		playerController.rigidbody2D.velocity = new Vector2(playerController.maxSpeedX,-10);
		playerController.SlideNaDole = true;
		playerController.Glide = true;
	}
}
