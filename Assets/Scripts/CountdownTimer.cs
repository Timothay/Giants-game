using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    float currentTime;
    float startingTime = 120;

    public TextMeshProUGUI countText;

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
        }
    }
}
