using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speedInMPerSec = 2f; // m/frame = m/s * Time.deltaTime
    public float leftAndRightEdge = 25f;
    public float chanceOfDirectionChange = 0.1f; //10% chance to change direction
    public float directionChangeDelay = 1f; //1 second delay between direction changes

    public int health = 5;

    private bool canChangeDirection = true;

    void Start()
    {

    }

    void Update()
    {
        Move();
        ChangeDirectionRandomly();
        if (health <= 0)
        {
            // Destroy the enemy when its health reaches zero or below.
            Destroy(this.gameObject);
        }
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
        }
    }

    IEnumerator ResetDirectionChangeDelay()
    {
        yield return new WaitForSeconds(directionChangeDelay);
        canChangeDirection = true;
    }

    void FixedUpdate()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            // Decrease enemy's health when hit by a player's bullet.
            health -= 1;
            Debug.Log(health);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(Vector3.zero, (new Vector3(leftAndRightEdge, Camera.main.orthographicSize - 1, leftAndRightEdge)) * 2);
    }
}