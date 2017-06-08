using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour {

    public float speed;
    private RectTransform position;


    void Awake()
    {
        position = GetComponent<RectTransform>();
    }
	
	void Update () {
        position.localPosition += Vector3.left * speed;
    }




    public RectTransform GetPosition()
    {
        return position;
    }
}
