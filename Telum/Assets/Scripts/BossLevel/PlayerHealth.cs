using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public AudioClip playerDamage;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            AudioSource.PlayClipAtPoint(playerDamage, transform.position);
            currentHealth--;
            Debug.Log(currentHealth);
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}