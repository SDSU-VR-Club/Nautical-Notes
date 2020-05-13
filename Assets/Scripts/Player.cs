using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{


    public int maxHealth2;
    public static int maxHealth;
    public static int currentHealth;

    public HealthBar healthBar;
    public static HealthBar healthBar2;
    // Start is called before the first frame update
    void Start() 
    { 
        maxHealth=maxHealth2;
        currentHealth = maxHealth;
        healthBar2=healthBar;
        healthBar2.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar2.SetHealth(currentHealth);
        if(currentHealth<0)
            defeat();
    }
    static void defeat(){
        SceneManager.LoadScene("defeat");
    }
    public static void HealDamage(int heal)
    {
        currentHealth += heal;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            healthBar2.SetMaxHealth(maxHealth);
        }
        healthBar2.SetHealth(currentHealth);
        
    }
}
