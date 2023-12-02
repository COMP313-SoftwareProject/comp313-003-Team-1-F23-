using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 moveDir;

    [SerializeField] float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
    }

    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        // Calculate the player's new position based on input and speed
        Vector2 newPosition = rb.position + moveDir * moveSpeed * Time.fixedDeltaTime;

        // Perform a Rigidbody2D move position, which includes collision detection
        rb.MovePosition(newPosition);
    }
}
