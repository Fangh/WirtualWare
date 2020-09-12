using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshPro textScore;
    // Start is called before the first frame update

    void Start()
    {
        GameManager.Instance.levelManager.OnLevelLoaded += PositionScoreText;
    }

    private void PositionScoreText()
    {
        GameObject textScoreOBJ = GameObject.FindGameObjectWithTag("ScoreText");
        textScore = textScoreOBJ.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore()
    {
        score++;
        textScore.text = "Score : " + score;

    }
}
