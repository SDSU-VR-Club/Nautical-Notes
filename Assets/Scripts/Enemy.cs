﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    bool vulnerable=false;
    bool dead;
    Rigidbody rb;
    public AudioClip skeleAttackSound;
    public AudioClip skeleDieSound;
    public float attackSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnMouseDown()
    {
        print("attack attempt");
        if (vulnerable)
            Destroy(gameObject);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(!dead)
            rb.velocity = transform.forward * speed;
        if (vulnerable && !dead)
        {
            rb.velocity = Vector3.zero;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        print("entered zone");
        vulnerable = true;
        if (!dead)
            attack();
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    print("exited zone");
    //    vulnerable = false;
    //}
    private void attack()
    {
        var anim = GetComponentInChildren<Animator>();
        anim.SetFloat("speedh", 0);
        anim.SetBool("Attack1h1", true);
        SoundManager.instance.RandomizeSfx(skeleAttackSound);
        StartCoroutine(damageDelay());
    }
    private IEnumerator damageDelay()
    {
        
        yield return new WaitForSeconds(attackSpeed);
        if(!dead)
        FindObjectOfType<Player>().TakeDamage(25);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Weapon"))
        {
            StartCoroutine(die());            
        }
        else if (collision.collider.CompareTag("Enemy")&&!dead)
        {
            StartCoroutine(die());
        }
        else
        {
            
        }
    }
    private IEnumerator die()
    {
        if (!dead)
        {
            dead = true;
            vulnerable = false;
            rb.useGravity = true;
            //GetComponentInChildren<Animator>().SetTrigger("Fall1");
            SoundManager.instance.RandomizeSfx(skeleDieSound);
            GetComponentInChildren<EnemyRagdoller>().die();
        }
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
