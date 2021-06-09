using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public int health = 100;
    public int healthMax = 100;

    public HealthBar healthbar;
    public Animator animator;


    public void Start()
    {
        animator.SetBool("isDead", false);
        health = healthMax;
        healthbar.SetMaxHealth(healthMax);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Damage(20);
        }

        if(health <= 0)
        {

            StartCoroutine(onDeathPause());
        }
    }

    public int GetHealth()
    {
        return health;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        if (health < 0) health = 0;
        healthbar.SetHealth(health);
        if(health == 0)
        {
            animator.SetBool("isDead", true);
        }
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > healthMax) health = healthMax;
        healthbar.SetHealth(health);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Damage(5);
        }
    }

    IEnumerator onDeathPause()
    {
        yield return new WaitForSeconds(2);
        FindObjectOfType<GameStateManager>().EndGame();
        Time.timeScale = 0;
    }
}
