using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWeapon : MonoBehaviour
{
    public Transform bottle;
    Rigidbody bottleRb;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = bottle.position - transform.position;
        bottleRb = bottle.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldSpace = Camera.main.ScreenToWorldPoint(mousePos - new Vector3(0, 0, offset.x));
        bottleRb.MovePosition(worldSpace);
    }
}
