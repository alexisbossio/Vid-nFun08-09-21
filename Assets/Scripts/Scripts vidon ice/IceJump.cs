using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceJump : MonoBehaviour {

	public Rigidbody2D ballRigidbody;
	public CircleCollider2D circleCollider;
	public SpriteRenderer sp;
	private float timer = 0;
	private bool startTimer = false;
	private AudioSource jumpSound;
	void Start() {
		jumpSound = GameObject.Find ("jump").GetComponent<AudioSource> ();
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (Vars.canJump == true) {
				transform.parent = null;
				GetComponent<CircleCollider2D> ().enabled = true;
				ballRigidbody.isKinematic = false;
				circleCollider.isTrigger = true;
				ballRigidbody.velocity = Vector2.zero;
				ballRigidbody.AddForce (new Vector2 (0, 600));
				Vars.canJump = false;
				if (!jumpSound.isPlaying) {
					jumpSound.Play ();
				}
			}
		}
		if (ballRigidbody.velocity.y < 0) {
			circleCollider.isTrigger = false;
		}
		if (startTimer == true) {
			timer += Time.deltaTime;
			if (timer >= 0.7f) {
				timer = 0;
				startTimer = false;
				Vars.canJump = true;
			}
		}
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (ballRigidbody.velocity.y < 0) {
			sp.sortingOrder = 1;
			startTimer = true;
		}
	}
	void OnTriggerExit2D(Collider2D col) {
		sp.sortingOrder = 3;
	}

}
