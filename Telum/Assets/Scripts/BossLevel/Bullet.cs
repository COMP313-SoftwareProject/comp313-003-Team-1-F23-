using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioClip EnemyDamage;

    void OnCollisionEnter2D(Collision2D other)
    {
        // Destroy the bullet when it collides with any 2D collider except the player game object.
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Boss"))
        {
            AudioSource.PlayClipAtPoint(EnemyDamage, transform.position);
            Destroy(gameObject);
        }
    }
}