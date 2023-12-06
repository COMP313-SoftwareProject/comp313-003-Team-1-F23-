using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{
    public float speed = 4.0f, rspeed = 2.0f;
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
        transform.Rotate(0, 0, 360 * rspeed * Time.deltaTime);
    }
}
