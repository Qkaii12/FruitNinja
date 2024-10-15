using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class GameManager : MonoBehaviour
{
    int score;
    int lives = 3;
    public TextMeshProUGUI timerText;
    public float remainingTime;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool gameIsOver;
    void Start()
    {
        score = 0;
    }
    public void UpdateTheScore(int scorePointsToAdd)
    {
        score += scorePointsToAdd;
        scoreText.text = score.ToString();
    }
    public void UpdateLives() 
    {
        if(gameIsOver == false)
        {
            lives--;
            livesText.text = "Lives: " + lives;
            if (lives == 0)
            {
                GameOver();
            }
        }
    }
    public void GameOver()
    {
        gameIsOver = true;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
    public void RestartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void Update()
    {
        UpdateTimer();
    }
    public void UpdateTimer()
    {
        if (gameIsOver == false) 
        {
           if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            GameOver();
            remainingTime = 0;
            timerText.color = Color.red;
            
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); 
        }
    }
}
