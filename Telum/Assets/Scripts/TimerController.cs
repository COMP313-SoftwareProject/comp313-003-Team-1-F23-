using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    private GameObject timer;
    private Text text;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        if (startTime == 0)
        {
            startTime = Time.time;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // find the Timer text
        timer = GameObject.Find("Timer");

        // get the Text component
        text = timer.GetComponent<Text>();

        // Calculate elapsed time
        float elapsedTime = Time.time - startTime;

        // Update text with elapsed time, should be formatted as hh:mm:ss
        text.text = string.Format("{0:00}:{1:00}:{2:00}", (int)elapsedTime / 3600, (int)elapsedTime / 60, (int)elapsedTime % 60);
        

    }
}
