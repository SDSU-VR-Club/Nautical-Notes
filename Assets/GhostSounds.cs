using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSounds : MonoBehaviour
{
    public AudioClip swing;
    public AudioClip hitSkeleton;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        SwingBottle();

    }
    void SwingBottle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //swingSource.Play();
            audioSource.PlayOneShot(swing, 1.0f);
        }
    }
    void OnColliderEnter (Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            audioSource.PlayOneShot(hitSkeleton, 1.0f);
            Destroy(collision.gameObject);
        }
    }
}

