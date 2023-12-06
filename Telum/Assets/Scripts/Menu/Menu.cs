using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public void StartButton()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}