using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScaler : MonoBehaviour {

	void Start() {
//		float scaleFactor = CanvasScaleFactor.s * 0.8f;
//		//Debug.Log (CanvasScaleFactor.s);
//		GetComponent<RectTransform> ().localScale = new Vector3 (scaleFactor, scaleFactor);
		StartCoroutine(Scale());
	}
		
	IEnumerator Scale() {
		yield return new WaitForSeconds (0.1f);
		float scaleFactor = CanvasScaleFactor.s * 0.5f;
		//Debug.Log (CanvasScaleFactor.s);
		GetComponent<RectTransform> ().localScale = new Vector3 (scaleFactor, scaleFactor);
	}
}
