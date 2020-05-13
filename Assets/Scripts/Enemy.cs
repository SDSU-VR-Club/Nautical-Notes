using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    bool vulnerable=false;
    bool dead;
    Rigidbody rb;
    public AudioClip skeleAttackSound01;
    public AudioClip skeleAttackSound02;
    public AudioClip skeleAttackSound03;
    public AudioClip skeleAttackSound04;
    public AudioClip skeleDieSound;
    public float attackSpeed;
    public Material highlight;
    public Material stock;
    public EnemyRagdoller ragdoller;
    public MeshRenderer renderer;
    public SkinnedMeshRenderer body;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnEnable()
    {
        dead=false;
        if(rb==null)
            rb = GetComponent<Rigidbody>();
        rb.velocity=Vector3.zero;
            rb.angularVelocity=Vector3.zero;
        rb.useGravity = false;
        
            body.material=stock;
            renderer.material=stock;
        
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
        if(other.CompareTag("highlight")){
             body.material=highlight;
            renderer.material=highlight;
        
        }
        else{
        print("entered zone");
        vulnerable = true;
        if (!dead)
            attack();
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    print("exited zone");
    //    vulnerable = false;
    //}
    private void attack()
    {
        anim.SetFloat("speedh", 0);
        anim.SetBool("Attack1h1", true);
        
        SoundManager.instance.RandomizeSfx(skeleAttackSound01, skeleAttackSound02, skeleAttackSound03, skeleAttackSound04);
        StartCoroutine(damageDelay());
    }
    private IEnumerator damageDelay()
    {
        
        yield return new WaitForSeconds(attackSpeed);
        if(!dead){
            Player.TakeDamage(25);
            gameObject.SetActive(false);
            EventManagerNoRythm.pool.Add(this);
            dead=true;
        }
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
            ragdoller.die();
        
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
        EventManagerNoRythm.pool.Add(this);
        }

    }
}
