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

    private void Start()
    {
        source = GetComponent<AudioSource>();
        volumeCheck = new float[1];
        generationVolume = 0.51f;

        arrowGeneration = GameObject.Find("SpawnPoint").GetComponent<ArrowGeneration>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        source.GetOutputData(volumeCheck, 0);
        if (Mathf.Abs(volumeCheck[0]) > generationVolume)
        {
            if (timer >= 0.7) //cooldown time for generating arrows
            {
                arrowGeneration.ArrowSpawn();//calls function to generate a random arrow
                timer = 0;
            }
        }
    }

    public void isPlaying()
    {
        source.Play(0); //plays the music
    }
    public void isPaused()
    {
        source.Pause(); //pauses the music
    }
}
