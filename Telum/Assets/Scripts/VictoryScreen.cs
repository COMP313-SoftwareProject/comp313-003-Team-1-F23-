using UnityEngine;
using UnityEngine.SceneManagement;


public class VictoryScreen : MonoBehaviour
{
    public GameObject victoryScreenUI;
   // public Animator transition;
    
    public void WinScreen()
    {
        victoryScreenUI.SetActive(true);
    }

    
    public void Restart()
    {
        Application.LoadLevel(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    

    public void RestartGame()
    {
        Application.LoadLevel(1);
        Time.timeScale = 1f;
    }
}
