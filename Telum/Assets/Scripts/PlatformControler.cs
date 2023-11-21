using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControler : MonoBehaviour
{
    public Platforms platform;

    public string crystalColor = "White";
    private float normalSpeed;
    private bool PlayerInRange = false;
    private bool isActive = false;
    public GameObject crystalHolder;
    // Start is called before the first frame update
    void Start()
    {
        platform.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {/*
        if (PlayerInRange)
        {
            if (isActive == false)
            {
                Activate();
            }

        }else if(!PlayerInRange)
        {
            Deactivate();
        }*/
    }

    public void Activate()
    {
        platform.speed = 4;

        isActive = true;
    }

    public void Deactivate()
    {
        isActive = false;
        platform.speed = 0;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            Debug.Log(PlayerInRange);
            collision.GetComponent<SpriteRenderer>().enabled = false;
            crystalHolder.GetComponent<SpriteRenderer>().sprite = collision.GetComponent<SpriteRenderer>().sprite;

            if (collision.name.Equals(crystalColor))
            {
                Activate();
            }
        }

    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            Debug.Log(PlayerInRange);
            collision.GetComponent<SpriteRenderer>().enabled = true;
            crystalHolder.GetComponent<SpriteRenderer>().sprite = null;

            if (collision.name.Equals(crystalColor))
            {
                Deactivate();
            }
        }

    }


}
