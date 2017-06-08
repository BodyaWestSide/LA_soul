using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour {

    public GameObject[] cameras;
    public float timeBetweenChange;
    
    void Start()
    {
        Invoke("ChangeCamera", timeBetweenChange);
    }

    void ChangeCamera()
    {
        for (int i = 0; i < cameras.Length; i++)
            cameras[i].SetActive(false);

        int id = Random.Range(0, cameras.Length);
        cameras[id].SetActive(true);

        Invoke("ChangeCamera", timeBetweenChange);
    } 
}
