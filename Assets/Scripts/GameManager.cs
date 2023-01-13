using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject playerPrefab;
    GameObject startHead;

    int points;

    int pointsMultiplier = 10;

    public TMP_Text pointsText;

    public TMP_Text pointsTextEnd;
    public TMP_Text topHighscoreText;

    private int[] topHighScores = new int[5];

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        for(int i = 0; i < topHighScores.Length; i++) {
            topHighScores[i] = PlayerPrefs.GetInt($"score{i}");
        }
    }

    void Update()
    {
        ShowPoints();
    }

    public void ShowPlayer() {
        startHead = Instantiate(playerPrefab, playerPrefab.transform.position, playerPrefab.transform.rotation);
        points = 0;
    }

    public int PointsMultiplier {
        get {return pointsMultiplier;}
        set {pointsMultiplier = value;}
    }

    public void AddPoints() {
        points += pointsMultiplier;
    } 

    public void ShowPoints() {
        pointsText.text = "Your score: " + points.ToString();
    }

    public void GameOver() {
        Destroy(startHead);
        if(!Array.Exists(topHighScores, element => element == points)) {
            if(points > topHighScores[topHighScores.Length - 1]) {
                UIManager.instance.ShowNewHighscoreText();
                topHighScores[topHighScores.Length - 1] = points;
                Array.Sort(topHighScores);
                Array.Reverse(topHighScores);
                for(int i = 0; i < topHighScores.Length; i++) {
                    PlayerPrefs.SetInt($"score{i}", topHighScores[i]);
                }
            }
        }
        pointsTextEnd.text = "Your total score is: " + points.ToString();
        UIManager.instance.ShowGameOverMenu();
    }

    public void ShowHighscoreTable() {
        string text = "";
        for(int i = 0; i < topHighScores.Length; i++) {
            text += $"{i + 1}. {topHighScores[i]}\n";
        }
        topHighscoreText.text = text;
    }
}
