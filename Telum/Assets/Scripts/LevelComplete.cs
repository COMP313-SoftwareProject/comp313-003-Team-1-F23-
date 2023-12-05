using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            FindObjectOfType<VictoryScreen>().WinScreen();
            Time.timeScale = 0f;
        }
    }
    
   
}



