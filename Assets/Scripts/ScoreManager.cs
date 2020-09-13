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
        GameManager.Instance.levelManager.OnLevelLoaded += PositionScoreText;
    }

    private void PositionScoreText()
    {
        GameObject textScoreOBJ = GameObject.FindGameObjectWithTag("ScoreText");
        textScore = textScoreOBJ.GetComponent<TextMeshPro>();
    }

    public void IncrementScore()
    {
        score++;
        textScore.text = "Score : " + score;
    }
}
