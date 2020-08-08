using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int maxHealth = 1;
    private int currentHealth;
    public int deathSound;
    public GameObject deathEffect;

    void Start() => currentHealth = maxHealth;

    public void TakeDamage()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            AudioManager.instance.PlaySFX(deathSound);
            Destroy(gameObject);
            PlayerController.instance.Bounce();
            Instantiate(deathEffect, transform.position + new Vector3(0, 1.2f, 0f), transform.rotation);
        }
    }
}
