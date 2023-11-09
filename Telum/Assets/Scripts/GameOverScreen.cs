using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    bool gameDeath = false;
    public GameObject deathScreenUI;
    public void GameOver()
    {
        if (gameDeath == false)
        {
            gameDeath = true;
        }
        if (gameDeath == true)
        {
            deathScreenUI.SetActive(true);
            Time.timeScale = 0f;
        }

    }
    public void LoadMenu()
    {
        
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        Application.LoadLevel(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}
