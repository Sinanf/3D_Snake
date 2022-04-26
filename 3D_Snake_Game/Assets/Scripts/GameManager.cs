using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool isPaused = false;
    public bool gameHasEnded = false;

    public PlayerController playerController;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    

    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
        
    }

    public void Pause()
    {
        
        if (isPaused == false)
        {
            Time.timeScale = 0f;
            isPaused = true;

        }
        else 
        {
            Resume();
        }
        
    }

    public void GameOver()
    {
       
            if (playerController.isAlive == false)
            {
                gameHasEnded = true;
                playerController.gameOverUI.SetActive(true);
                Time.timeScale = 0f;
            }
                    
    }



}
