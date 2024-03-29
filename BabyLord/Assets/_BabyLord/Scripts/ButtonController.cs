using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public AudioController source;
    public bool playState = false;
    PlayerController enemy;
    private void Start()
    {
        source = GameObject.Find("MusicSource").GetComponent<AudioController>();
        enemy = GameObject.Find("Player").GetComponent<PlayerController>();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (playState == false && enemy.activeEnemy == true)//checks if the music is being played or paused
            {
                source.isPlaying();
                playState = true;
            }
            else if (playState == true && enemy.activeEnemy == true)
            {
                source.isPaused();
                playState = false;
            }
        }
    }
}
