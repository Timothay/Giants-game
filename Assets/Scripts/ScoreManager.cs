using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public int score;
    public int highscore;

    void Start()
    {
        score = 0;
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        scoreText.text = highscore.ToString();
    }

    void Update()
    {
        if(score > highscore) {
            highscore = score;
            PlayerPrefs.SetInt("High score", highscore);
            highScoreText.text = "Meilleur Score : " + highscore.ToString();
        }
        scoreText.text = "Score : " + score.ToString();

    }
    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("High score", highscore);
        PlayerPrefs.Save();
    }
}