using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuMoving : MonoBehaviour {

	private Vector3 rotateRate = new Vector3 (1, 1, 0);
	// Use this for initialization
	void Start () {
		InvokeRepeating ("DoPunch", 0, 3f);
	}

	void DoPunch() {
		float duration = Random.Range (0.5f, 1.5f);
		int   vibrato  = Random.Range (3, 10);
		transform.DOPunchRotation (rotateRate, duration, vibrato);	
	}

}
