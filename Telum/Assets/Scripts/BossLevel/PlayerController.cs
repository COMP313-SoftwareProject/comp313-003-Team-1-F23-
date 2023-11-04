using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.5f;
    private float nextFire = 0f;
    public AudioClip PlayerShootSound;


    public enum PlayerColor
    {
        Red,
        Yellow,
        Green,
        White,
    }

    public PlayerColor currentColor;

    private void ColorSwitcher()
    {

        if (currentColor == PlayerColor.Red)
        {
            //change gameobject color to red
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            this.gameObject.tag = "PlayerRed";
        }
        if (currentColor == PlayerColor.Yellow)
        {
            //change color to yellow
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            this.gameObject.tag = "PlayerYellow";
        }
        if (currentColor == PlayerColor.Green)
        {
            //change color to green
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            this.gameObject.tag = "PlayerGreen";
        }
        if (currentColor == PlayerColor.White)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            this.gameObject.tag = "PlayerWhite";
        }

        // Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);
        // foreach (Collider2D collider in colliders)
        // {
        //     if (collider.gameObject.CompareTag("Red") && currentColor != PlayerColor.Red)
        //     {
        //         Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>(), true);
        //     }
        //     else if (collider.gameObject.CompareTag("White") && currentColor != PlayerColor.White)
        //     {
        //         Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>(), true);
        //     }
        //     else if (collider.gameObject.CompareTag("Green") && currentColor != PlayerColor.Green)
        //     {
        //         Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>(), true);
        //     }
        //     else if (collider.gameObject.CompareTag("Yellow") && currentColor != PlayerColor.Yellow)
        //     {
        //         Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>(), true);
        //     }
        //     else
        //     {
        //         Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>(), false);
        //     }
        // }
    }

    void Update()
    {
        // Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Customize controls
        float moveInput = 0;
        if (Input.GetKey("a"))
        {
            moveInput = -1f;
        }
        else if (Input.GetKey("d"))
        {
            moveInput = 1f;
        }

        Vector3 customMovement = new Vector3(moveInput, verticalInput, 0);
        transform.Translate(customMovement * moveSpeed * Time.deltaTime);

        // Shooting with the space bar
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }

        ColorSwitcher();
    }

    void Shoot()
    {
        // Create the bullet object
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        AudioSource.PlayClipAtPoint(PlayerShootSound, transform.position);

        bullet.GetComponent<Bullet>().playerController = this;

        // Set the bullet's velocity to move upward
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 10f);

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2f);
    }
}
