using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioClip EnemyDamage;

    private SpriteRenderer spriteRenderer;
    
    // get the currentColor of the player
    public PlayerController playerController;

    public void Start()
    {
        //get sprite renderer to switch colors
        spriteRenderer = GetComponent<SpriteRenderer>();
                ColorSwitcher();
    }

    // switch color based on playerColor Enum
    void ColorSwitcher(){
        if(playerController.currentColor == PlayerController.PlayerColor.Red){
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if(playerController.currentColor == PlayerController.PlayerColor.Yellow){
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else if(playerController.currentColor == PlayerController.PlayerColor.Green){
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if(playerController.currentColor == PlayerController.PlayerColor.White){
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

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