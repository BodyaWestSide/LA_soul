using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance = null;
    public enum PointType
    {
        Exelent,
        Good,
        Normal
    }

    public static int PerfectPointScore = 50;
    public static int GoodPointScore = 30;
    public static int BadPointScore = 10;

    public static int PerfectPointScoreOffset = 5;
    public static int GoodPointScoreOffset = 15;
    public static int BadPointScoreOffset = 30;

    public int perfectSerriesValue;
    public int goodSerriesValue;
    public int badSerriesValue;

	public  int score;
	public  int maxMissesValue = 5;
	private int missCount;
	private int seriesScore;
    private int seriesCheckFrequency = 5;
    private int seriesCheckCount;
	private List<GameObject> arrows = new List<GameObject> ();

	public Text scoreText;
	public Text yourScore;
	public Text yourBestScore;
	public GameObject gameOverScreen;
	public GameObject dancePanel;





    void Awake()
    {
        if (instance == null)
            instance = this;
    }




    public void AddScore(int points)
    {
        score += points;
        seriesScore += points;
		scoreText.text = "Score: " + score;

        MessageManager.instance.SetProgressText();
        seriesCheckCount++;
        CheckSerriesScore();
    }

	public void AddMiss() {
		missCount++;
		if (missCount > maxMissesValue) {
			SetGameOver ();
		}
	}

    private void CheckSerriesScore()
    {
        if (seriesCheckCount < seriesCheckFrequency)
            return;


        if (seriesScore > perfectSerriesValue)
        {
            MessageManager.instance.SetSeriesText(MessageManager.perfect);
            seriesScore = 0;
            seriesCheckCount = 0;
            return;
        }

        if (seriesScore > goodSerriesValue)
        {
            MessageManager.instance.SetSeriesText(MessageManager.good);
            seriesScore = 0;
            seriesCheckCount = 0;
            return;
        }

        if (seriesScore > badSerriesValue)
        {
            MessageManager.instance.SetSeriesText(MessageManager.bad);
            seriesScore = 0;
            seriesCheckCount = 0;
            return;
        }
    }


	public void AddArrowToList(GameObject arrow) {
		arrows.Add (arrow);
	}

	public void DeleteArrowFromList(GameObject arrow) {
		arrows.Remove (arrow);
	}

	public void CheckArrowsInput(string direction) {
		foreach (var arrow in arrows) {
			arrow.GetComponent<ArrowInteraction> ().
			CheckArrowPosition (direction);
		}
	}

	void CheckBestSCore() {
		if (score > SaveManager.instance.LoadBestScore()) {
			SaveManager.instance.SaveProgress (score);
			Debug.Log ("chekecd");
		}
	}

	void SetGameOver() {
		gameOverScreen.SetActive (true);
		dancePanel.SetActive (false);
		CheckBestSCore ();
		scoreText.text = "";
		yourScore.text = "Your score is " + score;
		yourBestScore.text = "Best score: " + SaveManager.instance.LoadBestScore (); 
	}

}
