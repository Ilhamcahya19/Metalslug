using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class aturScene : MonoBehaviour
{
    public GameObject panelPause;
    public void outGame()
    {
        Application.Quit();
    }
    public void inGame()
    {
        SceneManager.LoadScene("Gameplay"); 
    }
    public void startGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void endGame()
    {
        SceneManager.LoadScene("Credit");
    }
    public void pauseOn()
    {
        Time.timeScale = 0;
        panelPause.SetActive(true);
    }
    public void pauseOff()
    {
        Time.timeScale = 1;
        panelPause.SetActive(false);

    }
}
