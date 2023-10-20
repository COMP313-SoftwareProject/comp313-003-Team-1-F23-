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
    }

    void Shoot()
    {
        // Create the bullet object
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Set the bullet's velocity to move upward
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 10f);

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2f);
    }
}
