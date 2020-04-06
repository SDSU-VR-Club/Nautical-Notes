using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehaviour : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AttackAt(Vector3 pos)
    {
        transform.position = pos;
        anim.SetTrigger("attack");
    }
}
