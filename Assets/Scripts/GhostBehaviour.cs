using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehaviour : MonoBehaviour
{
    public Animator anim;
    public AudioClip swingSound01;
    public AudioClip swingSound02;
    public AudioClip swingSound03;
    public AudioClip swingSound04;
    public AudioClip swingSound05;
    public AudioClip swingSound06;
    public KeyCode[] keys;
    
    //AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(KeyCode key in keys){
            if(Input.GetKeyDown(key)){
                AttackAt();
                return;
            }
        }
    }
    private void OnMouseDown()
    {
        AttackAt();
    }
    public void AttackAt()
    {
        
            anim.SetTrigger("attack");
            //audioSource.PlayOneShot(swing, 0.6f);
            SoundManager.instance.RandomizeSfx(swingSound01, swingSound02, swingSound03, swingSound04, swingSound05, swingSound06);

        
    }
}
