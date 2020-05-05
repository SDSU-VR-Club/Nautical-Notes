using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class defeatVictoryScript : MonoBehaviour
{
    public GameObject TryAgainButton;
    public GameObject MainMenuButton;
    public GameObject QuitGameButton;

    public void TryAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
