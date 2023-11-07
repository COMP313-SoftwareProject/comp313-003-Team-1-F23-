using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    private Vector2 playerStartPos;

    // Start is called before the first frame update
    void Start()
    {
        //get player transform
        Transform playerTransform = GameObject.Find("Player").transform;
        //get player start positio nand store it
        playerStartPos = playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D other){
        // dont check tag just use reference to player
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if(player != null){
            //reset player to start position
            player.transform.position = playerStartPos;

        }
    }
}
