using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
	public GameObject gameOverUI;
	private AudioSource gameOverSound;
	void Start() {
		gameOverSound = GameObject.Find ("gameOver").GetComponent<AudioSource> ();
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.name.Contains ("ball")) {
			gameOverSound.Play ();
			Destroy (col.gameObject);
			gameOverUI.SetActive (true);
		}
	}
}
