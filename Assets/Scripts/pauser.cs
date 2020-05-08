using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pauser : MonoBehaviour
{
    bool paused=false;
    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        paused=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            paused=!paused;
            if( paused){
            Time.timeScale=0;
            music.Pause();
            }
            else{
            Time.timeScale=1;
            music.Play();
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
                Time.timeScale=1;
                SceneManager.LoadScene("Main Menu UI");
        }
        
    }
}
