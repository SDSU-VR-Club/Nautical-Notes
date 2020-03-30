using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    bool vulnerable=false;
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
    void Update()
    {
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
}
