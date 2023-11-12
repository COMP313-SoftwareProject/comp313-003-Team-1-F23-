using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    public float speed = 4.0f;
    public Transform target1, target2;

    Vector3 nextTarget;

    // Start is called before the first frame update
    void Start()
    {
        nextTarget = target1.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position == target1.position)
        {
            nextTarget = target2.position;
        }
        if (transform.position == target2.position)
        {
            nextTarget = target1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextTarget, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        collision.transform.SetParent(transform);

    }

    private void OnCollisionExit2D(Collision2D collision) 
    {
        collision.transform.SetParent(null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            speed = 0f;
        }
    }
}