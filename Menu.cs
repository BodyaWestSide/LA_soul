using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public GameObject loadingSreen;
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {
				Transform objectHit = hit.transform;

				if (objectHit.tag == "Play") {
					loadingSreen.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
					loadingSreen.SetActive (true);
					SceneManager.LoadScene (1);
				}
				if (objectHit.tag == "Exit") {
					Application.Quit ();
				}
			}
		}
	}
}
