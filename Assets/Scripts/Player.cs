using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    public int maxHealth = 4;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start() 
    { 
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HealDamage(25);
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth<0)
            defeat();
    }
    void defeat(){
        SceneManager.LoadScene("defeat");
    }
    public void HealDamage(int heal)
    {
        currentHealth += heal;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }
        healthBar.SetHealth(currentHealth);
    }
}
