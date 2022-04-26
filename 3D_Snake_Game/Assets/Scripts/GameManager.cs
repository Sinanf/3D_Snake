using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameStopped = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {

        if (gameStopped == false)
        {
            Time.timeScale = 0f;
            gameStopped = true;
        }
        else
        {
            Time.timeScale = 1f;
            gameStopped = false;
        }
        
    }

    
}
