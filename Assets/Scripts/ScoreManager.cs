using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;

    private TextMeshPro textScore;

    void Start()
    {
        GameManager.Instance.levelManager.OnLevelLoaded += GetScoreText;
    }

    private void GetScoreText()
    {
        textScore = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshPro>();
    }

    public void IncrementScore()
    {
        if (textScore == null)
            GetScoreText();

        score++;
        textScore.text = "Score : " + score;
    }
}
