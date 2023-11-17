using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text highscoreText;

    public Text timerText; // Add a timer field in the Unity editor

    public GameObject winCanvas; // Reference to the win canvas GameObject

    int score = 0;
    int highscore = 0;


    float gameTime = 180.0f;
    bool isGameActive = true;




    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();

        // Initialize and display the timer
        UpdateTimerText();
        InvokeRepeating("UpdateGameTime", 1.0f, 1.0f); // Invoke the method every second
    }


    void UpdateGameTime()
    {
        if (isGameActive)
        {
            gameTime -= 1.0f;
            UpdateTimerText();

            if (gameTime <= 0)
            {
                EndGame();
            }
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(gameTime / 60);
        int seconds = Mathf.FloorToInt(gameTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void EndGame()
    {
        isGameActive = false;
        winCanvas.SetActive(true);

        // Add any additional logic you want to execute when the game ends 
        Debug.Log("GameOver");
    }




    public void AddPoint()
    {
        if (isGameActive)
        {
            score += 1;
            scoreText.text = score.ToString() + " POINTS";

        }

            if (score > highscore)
            {
                highscore = score;
                PlayerPrefs.SetInt("highscore", highscore);
                highscoreText.text = "HIGHSCORE: " + highscore.ToString();  
            }
       
    }
    //This script includes a timer that counts down from 3 minutes and ends the game when the timer reaches zero. The UpdateTimerText method formats and displays the remaining time. The UpdateGameTime method is invoked every second to update the timer. The game ending logic is in the EndGame method, which you can customize based on your requirements.

}
