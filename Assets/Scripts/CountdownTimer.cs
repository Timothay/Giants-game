using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    float currentTime;
    float startingTime = 120;

    public TextMeshProUGUI countText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Image panel;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countText.text = currentTime.ToString("0") + "s left";

        if(currentTime <= 0)
        {
            currentTime = 0;
            GameObject.Find("ScoreText").GetComponent<ScoreManager>().SaveHighScore();
            countText.enabled = false;
            scoreText.enabled = false;
            gameOverText.enabled = true;
            panel.enabled = true;
        }
    }
}
