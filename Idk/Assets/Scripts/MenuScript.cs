using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MenuScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("PaddleGame");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Clicked the exit button");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
