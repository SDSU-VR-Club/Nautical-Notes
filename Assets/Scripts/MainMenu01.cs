using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu01 : MonoBehaviour
{

    public GameObject PlayGameButton;
    public GameObject HowToPlayButton;
    public GameObject QuitGameButton;
    public GameObject eventSystem;
    bool creditsOpen;
    bool htpOpen;
    public GameObject backButtonCredits;
    public GameObject credits;
    public GameObject creditsCanvas;
    public GameObject HowToPlayCanvas;
    public GameObject htpBack;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Back") && creditsOpen)
        {
            toggleCredits();
        }

        if(Input.GetButtonDown("Submit") && htpOpen)
        {
            toggleHowToPlay();
        }
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // make sure the TripplGhostScene is set as scene 1 in Build Settings
    }
    public void ViewCredits ()
    {
        toggleCredits();
    }
    void toggleCredits()
    {
        if(creditsOpen)
        {
            creditsCanvas.SetActive(false);
            eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(credits);
            creditsOpen = false;
        }
        else
        {
            creditsCanvas.SetActive(true);
            eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(backButtonCredits);
            creditsOpen = true;
        }
    }

    public void ViewHowToPlay ()
    {
        toggleHowToPlay();
    }

    void toggleHowToPlay()
    {   if (htpOpen)
        {
            HowToPlayCanvas.SetActive(false);
            eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(HowToPlayButton);
            htpOpen = false;
        }

        else
        {
            HowToPlayCanvas.SetActive(true);
            eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(htpBack);
            htpOpen = true;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
