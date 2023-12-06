using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PlayerMover : MonoBehaviour
{
    public float moveSpeed = 5f;

    #region Color Vars
    public PlayerColor currentColor;
    //enum to store current color of player
    public enum PlayerColor
    {
        Red,
        Yellow,
        Green,
        White,
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        currentColor = PlayerColor.Red;
    }

    // Update is called once per frame
    public void Update()
    {
        ColorSwitcher();
    }

    public void FixedUpdate()
    {
        Move();
    }

    #region Movement
    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(horizontal, vertical).normalized;

        GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;
    }
    #endregion

    #region Color Switch
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

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("Red") && currentColor != PlayerColor.Red)
            {
                Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>(), true);
            }
            else if (collider.gameObject.CompareTag("White") && currentColor != PlayerColor.White)
            {
                Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>(), true);
            }
            else if (collider.gameObject.CompareTag("Green") && currentColor != PlayerColor.Green)
            {
                Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>(), true);
            }
            else if (collider.gameObject.CompareTag("Yellow") && currentColor != PlayerColor.Yellow)
            {
                Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>(), true);
            }
            else
            {
                Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>(), false);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Red") && currentColor != PlayerColor.Red)
        {
            Debug.Log("hit red");
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>(), true);
        }
        else if (collision.gameObject.CompareTag("White") && currentColor != PlayerColor.White)
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>(), true);
        }
        else if (collision.gameObject.CompareTag("Green") && currentColor != PlayerColor.Green)
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>(), true);
        }
        else if (collision.gameObject.CompareTag("Yellow") && currentColor != PlayerColor.Yellow)
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>(), true);
        }
        else
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>(), false);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        // exit check if player is in trigger and pressing up

        if (other.gameObject.CompareTag("Exit"))
        {
            Debug.Log("Exit");
            // load next scene in build index
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    #endregion
}
