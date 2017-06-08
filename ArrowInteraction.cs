using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowInteraction : MonoBehaviour
{
    public int arrowType;
    public enum ArrowType
    {
        Top,
        Left,
        Down,
        Right
    }

    private ArrowDisplay arrowDisplay;
    private ArrowMove    arrowMove;
    private bool isPressed;



    void Awake()
    {
        arrowMove    = GetComponent<ArrowMove>();
        arrowDisplay = GetComponent<ArrowDisplay>();
    }

	void Start() {
		ScoreManager.instance.AddArrowToList (this.gameObject);
	}
		
    void Update()
    {
        CheckPosiion();
    }





    void CheckPosiion()
    {
        if (isPressed)
            return;

        if (arrowMove.GetPosition().localPosition.x < -50)
        {
			isPressed = true;
            arrowDisplay.DoFadeOut();
            Invoke("DeleteArrow", arrowDisplay.arrowFadeTime * 2);  
			ScoreManager.instance.AddMiss ();
        }


    }

	public void CheckArrowPosition(string arrow) {
		if (isPressed)
			return;

		float currentPosition = Mathf.Abs(arrowMove.GetPosition().localPosition.x);
		if (currentPosition < ScoreManager.PerfectPointScoreOffset)
		{
			if (ChekArrowMatcWithInput(arrow))
			{
				ScoreManager.instance.AddScore(ScoreManager.PerfectPointScore);

				arrowDisplay.DoFadeOut();
				arrowDisplay.DoFadeInRoundCircle(1);
				isPressed = true;
				Invoke("DeleteArrow", arrowDisplay.arrowFadeTime * 2);
				return;
			}
		}

		if (currentPosition < ScoreManager.GoodPointScoreOffset)
		{
			if (ChekArrowMatcWithInput(arrow))
			{
				ScoreManager.instance.AddScore(ScoreManager.GoodPointScore);

				arrowDisplay.DoFadeOut();
				arrowDisplay.DoFadeInRoundCircle(0.5f);
				isPressed = true;
				Invoke("DeleteArrow", arrowDisplay.arrowFadeTime * 2);
				return;
			}
		}

		if (currentPosition < ScoreManager.BadPointScoreOffset)
		{
			if (ChekArrowMatcWithInput(arrow))
			{
				ScoreManager.instance.AddScore(ScoreManager.BadPointScore);

				arrowDisplay.DoFadeOut();
				arrowDisplay.DoFadeInRoundCircle(0.3f);
				isPressed = true;
				Invoke("DeleteArrow", arrowDisplay.arrowFadeTime * 2);
				return;
			}
		}

	}

	public bool ChekArrowMatcWithInput(string key)
    {
		if (key.Equals("Up") &&
            arrowType == (int)ArrowType.Top)
            return true;

		if (key.Equals("Left") &&
            arrowType == (int)ArrowType.Left)
            return true;

		if (key.Equals("Down") &&
            arrowType == (int)ArrowType.Down)
            return true;

		if (key.Equals("Right") &&
            arrowType == (int)ArrowType.Right)
            return true;

        return false;
    }

    void DeleteArrow()
    {
        Destroy(this.gameObject);
		ScoreManager.instance.DeleteArrowFromList (this.gameObject);
    }
}
