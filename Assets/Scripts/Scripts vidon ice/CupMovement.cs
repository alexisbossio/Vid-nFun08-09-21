using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupMovement : MonoBehaviour {

	public Rigidbody2D cupRigidbody;
	private bool left = true;
	private float xPos = 0;
	// Use this for initialization
	void Start () {
		xPos = cupRigidbody.transform.position.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (left == true) {
			xPos += 0.05f + Vars.cupMovementSpeed;
		} else {
			xPos -= 0.05f + Vars.cupMovementSpeed;
		}
		if (xPos >= 2.5f) {
			left = false;
		}
		if (xPos <= -2.5f) {
			left = true;
		}
		cupRigidbody.MovePosition (new Vector2 (xPos, cupRigidbody.position.y));
	}
}
