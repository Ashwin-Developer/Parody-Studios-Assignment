using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 120f; // 2 minutes in seconds
    public TextMeshProUGUI timerText;

    private bool timerIsRunning = false;

    private void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                GameManager.instance.ToggleGameOverPanel();
            }
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        timeToDisplay += 1; // To make the timer display in a more user-friendly way

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
