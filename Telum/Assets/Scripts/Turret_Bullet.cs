using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Bullet : MonoBehaviour
{

    public float speed;
    Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = transform.right * speed;
        Destroy(gameObject,4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            
        }
        else if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
