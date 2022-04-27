using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    public List<int> scoreList = new List<int>();

    int score = 0;
    int highScore;

    private void Awake()
    {
        instance = this;     
        
    }

    
    void Start()
    {
        
        highScore = PlayerPrefs.GetInt("highscore");
        scoreText.text = score.ToString() + " Points";
        highScoreText.text = "Highscore: " + highScore.ToString();
        scoreList.Capacity = 5;
        
    }

    

    public void AddPoint()
    {
        score++;
        scoreText.text = score.ToString() + " Points";
        if (highScore < score)
        {
            scoreList.Add(highScore);
            highScore = score;
            PlayerPrefs.SetInt("highscore", highScore);
            highScoreText.text = "Highscore: " + highScore.ToString();
            

            
            PlayerPrefs.Save();          

        }
    }

        
}
