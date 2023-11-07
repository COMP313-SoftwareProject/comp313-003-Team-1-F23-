using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorMenuController : MonoBehaviour
{
    public GameObject panel;
    public GameObject player;

    public PlayerMovement playerController;

    //list of buttons
    public List<Button> buttons;

    //coroutine for slowing down time
    IEnumerator SlowDownTime(float target, float duration)
    {
        float start = Time.timeScale;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            elapsed += Time.unscaledDeltaTime; // Use unscaledDeltaTime so the slowdown doesn't affect the lerp
            Time.timeScale = Mathf.Lerp(start, target, elapsed / duration);
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            panel.SetActive(true);
            // StartCoroutine(SlowDownTime(0.5f, 0.5f));
            panel.transform.position = player.transform.position + new Vector3(0, 3, 0);
        }
        else
        {
            panel.SetActive(false);
            // StartCoroutine(SlowDownTime(1f, 0.5f));
        }

        //if panel is active
        if (panel.activeSelf)
        {
            // Add your code here
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // Select the first button
                playerController.currentColor = PlayerMovement.PlayerColor.Green;
                Debug.Log("first color");
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // Select the second button
                playerController.currentColor = PlayerMovement.PlayerColor.Yellow;
                Debug.Log("second color");
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // Select the third button
                playerController.currentColor = PlayerMovement.PlayerColor.Red;
                Debug.Log("third color");
            }
        }



    }
}
