using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speedInMPerSec = 3f; // m/frame = m/s * Time.deltaTime
    public float leftAndRightEdge = 9f;
    public float chanceOfDirectionChange = 0.1f; //10% chance to change direction
    public float directionChangeDelay = 1f; //1 second delay between direction changes
    public GameObject enemyBulletPrefab;
    public float bulletSpeed = 5f;
    public Transform firePoint;

    private bool canChangeDirection = true;

    void Start()
    {
    }

    void Update()
    {
        Move();
        ChangeDirectionRandomly();
    }

    private void CheckForDirChangeAndChangeIfNecessary()
    {
        Vector3 pos = this.transform.position;
        if (pos.x > leftAndRightEdge)
        {
            speedInMPerSec *= -1;
            pos.x = leftAndRightEdge;
            this.transform.position = pos;
        }
        else if (pos.x < -leftAndRightEdge)
        {
            speedInMPerSec *= -1;
            pos.x = -leftAndRightEdge;
            this.transform.position = pos;
        }
    }

    private void Move()
    {
        CheckForDirChangeAndChangeIfNecessary(); // Check for direction change before moving.
        Vector3 pos = this.transform.position;
        pos.x = pos.x + speedInMPerSec * Time.deltaTime;
        this.transform.position = pos;
    }

    private void ChangeDirectionRandomly()
    {
        if (canChangeDirection)
        {
            float randomValue = Random.value;
            if (randomValue < chanceOfDirectionChange)
            {
                speedInMPerSec *= -1;
            }
            canChangeDirection = false;
            StartCoroutine(ResetDirectionChangeDelay());
            Shoot();
        }
    }

    IEnumerator ResetDirectionChangeDelay()
    {
        yield return new WaitForSeconds(directionChangeDelay);
        canChangeDirection = true;
    }


    private void Shoot()
    {
        GameObject bullet = Instantiate(enemyBulletPrefab, firePoint.position, Quaternion.identity);
        bullet.layer = LayerMask.NameToLayer("EnemyBullet");
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = Vector2.down * bulletSpeed;
        Destroy(bullet, 2f);
    }

    // Draw a yellow wire cube in the editor to show the left and right edge of the screen
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(Vector3.zero, (new Vector3(leftAndRightEdge, Camera.main.orthographicSize - 1, leftAndRightEdge)) * 2);
    }
}