using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MessageManager : MonoBehaviour {

    public static MessageManager instance = null;


    public Text seriesText;
    public Text progressText;

    private float progressMessageTimer;
    public  float timeBetweenMissingProgressMessage;
    public  string[] progressMessages =
    {
        "keep it up ma boy",
        "all ledies yours"
    };

    public static string perfect = "perfect";
    public static string good    = "good";
    public static string bad     = "bad";

    private Color perfectColor = new Color(225, 227, 0);
    private Color goodtColor   = new Color(0, 0, 255);
    private Color badColor     = new Color(214, 0, 0);



    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Update()
    {
        if (progressMessageTimer > timeBetweenMissingProgressMessage)
            progressText.text = "";

        progressMessageTimer += Time.deltaTime;
    }




    public void SetSeriesText(string text)
    {
        seriesText.text = text;

        if (text == perfect)
            seriesText.color = perfectColor;

        if (text == good)
            seriesText.color = goodtColor;

        if (text == bad)
            seriesText.color = badColor;
    }

    public void SetProgressText()
    {
        int id = Random.Range(0, progressMessages.Length);
        progressText.text = progressMessages[id];
        progressMessageTimer = 0;
    }
}
