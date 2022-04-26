using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    int score = 0;
    int highScore = 0;

    private void Awake()
    {
        instance = this;   
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        scoreText.text = score.ToString() + " Points";
        highScoreText.text = "Highscore: " + highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoint()
    {
        score++;
        scoreText.text = score.ToString() + " Points";
        if (highScore < score)
        {
            PlayerPrefs.SetInt("highscore", score);

        }
    }
}
