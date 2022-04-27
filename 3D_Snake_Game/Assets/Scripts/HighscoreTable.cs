using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighscoreTable : MonoBehaviour
{
    
    public ScoreManager scoreManager;

    
    public int currentHighScore;       
    public int temp;

    public TMP_Text firstHighscoreText;
    

    
    void Start()
    {
        currentHighScore = PlayerPrefs.GetInt("highscore");        
        firstHighscoreText.text = currentHighScore.ToString();

    }

}


