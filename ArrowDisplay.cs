using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDisplay : MonoBehaviour {


    public Image circleImage;
    public Image arrowImage;
    public float arrowFadeTime;
    public float circleFadeTime;

    void Awake()
    {
        circleImage.canvasRenderer.SetAlpha(0.0f);
        arrowImage.canvasRenderer.SetAlpha(0.0f);
    }

	void Start() {
		float fadeTime = 1 -(GetComponent<ArrowMove> ().speed / 3 - 1);
		if (fadeTime < 0.25){
			fadeTime = 0.25f;
		}
		arrowImage.CrossFadeAlpha(1, fadeTime * 2, false);
		Debug.Log (fadeTime);
	}


    public void DoFadeOut()
    {
		arrowImage.CrossFadeAlpha(0, arrowFadeTime, false);
    }

    public void DoFadeInRoundCircle(float alpha)
    {
        circleImage.CrossFadeAlpha(alpha, circleFadeTime, false);
        Invoke("DoFadeOutRoundCircle", circleFadeTime);
    }
	
    private void DoFadeOutRoundCircle()
    {
        circleImage.CrossFadeAlpha(0, circleFadeTime, false);
    }
}
