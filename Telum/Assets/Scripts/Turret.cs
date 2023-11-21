using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform firepoint;
    public  GameObject bullet;
    float interval;
    public float startinterval;
    

    
    // Start is called before the first frame update
    void Start()
    {
        interval = startinterval;
    }

    // Update is called once per frame
    void Update()
    {
        if(interval <=0)
        {
            Instantiate(bullet, firepoint.position, firepoint.rotation);
            interval = startinterval;
            
        }
        else
        {
            interval -= Time.deltaTime;
        }
    }
    
}
