using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    bool vulnerable=false;
    bool dead;
    Rigidbody rb;
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
    }
    private void OnTriggerEnter(Collider other)
    {
        print("entered zone");
        vulnerable = true;
    }
    private void OnTriggerExit(Collider other)
    {
        print("exited zone");
        vulnerable = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Weapon"))
        {
            print("strike");
            dead = true;
            vulnerable = false;
            rb.useGravity = true;
        }
        else if (collision.collider.CompareTag("Enemy")&&!dead)
        {
            Destroy(collision.collider.gameObject);
            
        }
    }
}
