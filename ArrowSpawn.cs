using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour {

    public GameObject[] arrowsPrefab;
    public GameObject   parentObject;
    public Vector3 spawnPoint;
    public float spawnTime;

	private float speedAcelerAddValue = 0.1f;
	private float speedAcceler;


    void Awake()
    {
        StartCoroutine(SpawnArrow());
    }
		
    IEnumerator SpawnArrow()
    {
		while (true)
        { 
            GameObject arrow = Instantiate(arrowsPrefab[Random.Range(0, arrowsPrefab.Length)]);
            arrow.transform.SetParent(parentObject.transform);
            arrow.GetComponent<RectTransform>().localPosition = spawnPoint;
			arrow.GetComponent<ArrowMove> ().speed += speedAcceler;
			float scaleFactor = CanvasScaleFactor.s * 0.5f;
			arrow.GetComponent<RectTransform> ().localScale = new Vector3 (scaleFactor, scaleFactor);
            yield return new WaitForSeconds(spawnTime);
			speedAcceler += speedAcelerAddValue; 
        }
    }

}
