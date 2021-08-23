using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource source;
    float[] volumeCheck;
    private float timer;
    public float generationVolume;
    ArrowGeneration arrowGeneration;
    EnemyController enemy;
    public AudioClip[] clips;
    int index = 0;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        volumeCheck = new float[1];
        generationVolume = 0;

        arrowGeneration = GameObject.Find("SpawnPoint").GetComponent<ArrowGeneration>();
        enemy = GameObject.Find("GameController").GetComponent<EnemyController>();

    }

    private void Update()
    {
        timer += Time.deltaTime;
        source.GetOutputData(volumeCheck, 0);
        if (Mathf.Abs(volumeCheck[0]) > generationVolume)
        {
            if (timer >= enemy.coolDown) //cooldown time for generating arrows
            {
                arrowGeneration.ArrowSpawn();//calls function to generate a random arrow
                timer = 0;
            }
        }
    }

    public void isPlaying()
    {
        source.Play(0); //plays the music
        Time.timeScale = 1;
    }
    public void isPaused()
    {
        source.Pause(); //pauses the music
        Time.timeScale = 0;
    }

    public void ChangeSong()
    {
        source.clip = clips[index];
        index++;
        if (index > 4)
            index = 0;
    }
}
