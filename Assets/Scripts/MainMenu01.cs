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
    public GameObject CreditsButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // make sure the TripplGhostScene is set as scene 1 in Build Settings
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
