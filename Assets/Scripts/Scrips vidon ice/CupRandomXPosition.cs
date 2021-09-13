using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupRandomXPosition : MonoBehaviour {

	public GameObject cup;

	void Start () {
		float randXPos = Random.Range (-2.5f, 2.5f);
		cup.transform.position = new Vector2 (randXPos, cup.transform.position.y);
		Destroy (this);
	}

}
