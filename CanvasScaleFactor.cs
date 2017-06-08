using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScaleFactor : MonoBehaviour {

	public static float s;
	private Canvas canvas;

	void Awake() {
		canvas = GetComponent<Canvas> ();
	}

	void Update () {
		s = canvas.scaleFactor;
	}
}
