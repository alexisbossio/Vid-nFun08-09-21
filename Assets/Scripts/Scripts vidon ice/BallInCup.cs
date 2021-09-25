using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallInCup : MonoBehaviour {
	public CupMovement cupMovement;
	public Rigidbody2D rb;
	private GameObject mainCamera;
	private float cameraMovePositonY;
	private bool moveCamera = false;
	private float timer = 0;
	void Start() {
		mainCamera = GameObject.Find ("Main Camera");
	}
	void FixedUpdate() {
		if (moveCamera == true) {
			timer += Time.deltaTime;
			if (timer > 0.5f) {
				mainCamera.transform.position = Vector3.Lerp (mainCamera.transform.position, new Vector3 (0, cameraMovePositonY, -10), 0.11f);
				GameObject.Find ("ball").GetComponent<Rigidbody2D> ().isKinematic = true;
				GameObject.Find ("ball").GetComponent<CircleCollider2D> ().enabled = false;
				GameObject.Find ("ball").transform.parent = this.gameObject.transform;
				cupMovement.enabled = true;
				Vars.canJump = true;
				Vars.cupMovementSpeed += 0.001f;

			}
		}
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.name.Contains ("ball")) {
			if (col.gameObject.GetComponent<Rigidbody2D> ().velocity.y <= 0) {
				GameObject newPlatform = Instantiate(Resources.Load("cupPlatform"), new Vector3(0, transform.parent.transform.position.y + 5, 0), Quaternion.identity) as GameObject;
				rb.constraints = RigidbodyConstraints2D.None;
				rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
				moveCamera = true;
				cameraMovePositonY = newPlatform.transform.position.y-4;
				Destroy (this, 0.7f);
				GameObject.Find ("iceInGlass").GetComponent<AudioSource> ().Play ();
			}
		}
	}
	void OnDestroy()
	{
		Vars.score++;
		GameObject scoreText = GameObject.Find ("scoreText");
		if(scoreText != null) {
			scoreText.GetComponent<Text> ().text = "SCORE: " + Vars.score;
		}
	}
}
