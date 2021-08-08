using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    AudioController source;
    private bool playState = false;
    private void Start()
    {
        source = GameObject.Find("MusicSource").GetComponent<AudioController>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playState == false)//checks if the music is being played or paused
            {
                source.isPlaying();
                playState = true;
            }
            else if (playState == true)
            {
                source.isPaused();
                playState = false;
            }
        }
    }
}
