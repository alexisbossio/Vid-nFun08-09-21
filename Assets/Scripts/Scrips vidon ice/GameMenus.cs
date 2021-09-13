using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenus : MonoBehaviour {
	public GameObject mainUI;
	public GameObject gameUI;
	public GameObject gameOverMenuUI;
	public GameObject score;
	private Text scoreText;
	private AudioSource buttonSound;
	void Start () {
		scoreText = score.GetComponent<Text> ();
		buttonSound = GameObject.Find ("buttonClick").GetComponent<AudioSource> ();
	}
	public void play () {
		reset ();
		mainUI.SetActive (false);
		gameUI.SetActive (true);
		Instantiate (Resources.Load ("cupPlatformWithBall"), new Vector2 (0, 2), Quaternion.identity);
		Instantiate (Resources.Load ("cupPlatform"), new Vector2 (0, 7), Quaternion.identity);
		buttonSound.Play ();
	}
	public void exitToMainMenu () {
		removeAllObjects ();
		reset ();
		gameOverMenuUI.SetActive (false);
		mainUI.SetActive (true);
		gameUI.SetActive (false);
		buttonSound.Play ();
	}
	public void restart() {
		removeAllObjects ();
		gameOverMenuUI.SetActive (false);
		play ();
	}
	public void exitTheGame() {
		buttonSound.Play ();
		Application.Quit ();
	}
	private void reset() {
		GameObject.Find ("Main Camera").transform.position = new Vector3(0, 0, -10);
		Vars.cupMovementSpeed = 0;
		Vars.canJump = true;
		Vars.score = 0;
		scoreText.text = "SCORE: " + Vars.score;
	}
	private void removeAllObjects() {
		BallInCup[] ballInCup = GameObject.FindObjectsOfType<BallInCup> ();
		for (int i = 0; i < ballInCup.Length; i++) {
			Destroy (ballInCup [i]);
		}
		GameObject[] platforms = GameObject.FindGameObjectsWithTag ("platform");
		for (int i = 0; i < platforms.Length; i++) {
			DestroyImmediate  (platforms [i]);
		}
		GameObject[] ball = GameObject.FindGameObjectsWithTag ("ball");
		for (int i = 0; i < ball.Length; i++) {
			Destroy (ball [i]);
		}
	}
}
