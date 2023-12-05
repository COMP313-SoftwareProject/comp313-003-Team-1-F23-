using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSwitchSingleController : MonoBehaviour
{
    public Platforms platform;
    private float normalSpeed;
    private bool PlayerInRange = false;
    private bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        normalSpeed = platform.speed;
        platform.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E) && isActive == false)
            {
                Activate();
            }else if(Input.GetKeyDown(KeyCode.E) && isActive == true)
            {
                isActive = false;
                platform.speed = 0;
            }
        }
    }

    public void Activate()
    {
        if (normalSpeed != 0)
        {
            platform.speed = normalSpeed;
        }
        else
        {
            platform.speed = 3;
        }

        isActive = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = false;
        }
    }
}
