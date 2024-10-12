using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int score;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        score = 0;
    }
    public void UpdateTheScore(int scorePointsToAdd)
    {
        score += scorePointsToAdd;
        scoreText.text = score.ToString();
    }
}
