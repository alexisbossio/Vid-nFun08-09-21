using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOldObjects : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.name.Equals ("cup")) {
			Destroy (col.gameObject.transform.parent.gameObject);
		}
	}
}
