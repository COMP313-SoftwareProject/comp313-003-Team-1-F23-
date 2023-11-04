using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public AudioClip EnemyDamage;
    private int health = 10;
    private SpriteRenderer spriteRenderer;
    public GameObject player;

    public enum BossColor
    {
        Red,
        Yellow,
        Green,
        White,
    }

    public BossColor currentColor;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (health)
        {
            case 10:
                currentColor = BossColor.White;
                break;
            case 7:
                currentColor = BossColor.Green;
                break;
            case 5:
                currentColor = BossColor.Yellow;
                break;
            case 3:
                currentColor = BossColor.Red;
                break;

        }

        ColorSwitcher();
    }

    //Automatic Color switcher 
    public void ColorSwitcher()
    {
        switch (currentColor)
        {
            case BossColor.Red:
                spriteRenderer.color = Color.red;
                break;
            case BossColor.Yellow:
                spriteRenderer.color = Color.yellow;
                break;
            case BossColor.Green:
                spriteRenderer.color = Color.green;
                break;
            case BossColor.White:
                spriteRenderer.color = Color.white;
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {



        if (collision.gameObject.tag == "PlayerBullet")
        {
            // color checking basedon player current color and if the object is a bullet and and taking damage
            if (player.gameObject.CompareTag("PlayerRed") && currentColor == BossColor.Red)
            {
                TakeDamage();
                AudioSource.PlayClipAtPoint(EnemyDamage, transform.position);
            }
            else if (player.gameObject.CompareTag("PlayerYellow") && currentColor == BossColor.Yellow)
            {
                TakeDamage();
                AudioSource.PlayClipAtPoint(EnemyDamage, transform.position);
            }
            else if (player.gameObject.CompareTag("PlayerGreen") && currentColor == BossColor.Green)
            {
                TakeDamage();
                AudioSource.PlayClipAtPoint(EnemyDamage, transform.position);
            }
            else if (player.gameObject.CompareTag("PlayerWhite") && currentColor == BossColor.White)
            {
                TakeDamage();
                AudioSource.PlayClipAtPoint(EnemyDamage, transform.position);
            }

        }
    }
    public void TakeDamage()
    {
        health--;
        Debug.Log(health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}