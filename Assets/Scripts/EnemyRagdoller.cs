using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRagdoller : MonoBehaviour
{
    public Rigidbody[] rbs;
    // Start is called before the first frame update
    void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void die()
    {
        GetComponent<Animator>().enabled = false;
        foreach(Rigidbody rb in rbs)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }
}
