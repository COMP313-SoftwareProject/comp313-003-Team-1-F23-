using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
   

    void Update ()
    {
      
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (GameIsPaused)
            {
                
                Resume();
            }
            else
            {
                
                Pause();
            }
        }

    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
    }
     public  void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
    }
    
    
}
