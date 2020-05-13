using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRagdoller : MonoBehaviour
{
    public Rigidbody[] rbs2;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rbs2 = GetComponentsInChildren<Rigidbody>();
        animator=GetComponent<Animator>();
    }
    
    void OnEnable()
    {
        if(animator==null)
            animator=GetComponent<Animator>();
        animator.enabled = true;
        foreach(Rigidbody rb in rbs2)
        {
            rb.velocity=Vector3.zero;
            rb.angularVelocity=Vector3.zero;
            rb.isKinematic = true;
            rb.useGravity = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public  void die()
    {
        Player.HealDamage(10);
        animator.enabled = false;
        foreach(Rigidbody rb in rbs2)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }
}
