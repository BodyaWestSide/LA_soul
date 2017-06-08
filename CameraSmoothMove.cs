using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraSmoothMove : MonoBehaviour {

    public Transform defaultCameraPosition;
    public Transform tuningCameraPosition;


    void Awake()
    {
        Invoke("MoveToTuning", 3f);
    }


    public void MoveToTuning()
    {
        transform.DOMove(tuningCameraPosition.position, 3f);
        transform.DORotate(tuningCameraPosition.eulerAngles, 3f);
    }

}
