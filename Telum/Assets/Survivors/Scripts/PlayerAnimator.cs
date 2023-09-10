using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    PlayerMove playerMove;
    Animator animator;
    SpriteRenderer spriterenderer;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        animator = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.moveDir.x != 0 || playerMove.moveDir.y != 0)
        {
            animator.SetBool("Move", true);
            SpriteDirectionChecker();
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }

    void SpriteDirectionChecker()
    {
        if (playerMove.moveDir.x > 0)
        {
            spriterenderer.flipX = false;
        }
        else if (playerMove.moveDir.x < 0)
        {
            spriterenderer.flipX = true;
        }
    }
}
