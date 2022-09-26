using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        scoreText.text = "Score : " + score.ToString();
    }
}