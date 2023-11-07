using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource backgroundMusic;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMusic();
        }
    }

    public void ToggleMusic()
    {
        if (backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
        }
        else
        {
            backgroundMusic.Play();
        }
    }
}