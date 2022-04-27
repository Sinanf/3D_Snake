using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(2);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Levels()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Level1()
    {
        SceneManager.LoadScene(3);
    }

    public void Level2()
    {
        SceneManager.LoadScene(4);
    }

    public void Level3()
    {
        SceneManager.LoadScene(5);
    }

    public void Level4()
    {
        SceneManager.LoadScene(6);
    }

    public void Level5()
    {
        SceneManager.LoadScene(7);
    }

    public void Level6()
    {
        SceneManager.LoadScene(8);
    }

    public void Level7()
    {
        SceneManager.LoadScene(9);
    }

    public void Level8()
    {
        SceneManager.LoadScene(10);
    }

    public void HighscoreMenu()
    {
        SceneManager.LoadScene(11);
    }
}
