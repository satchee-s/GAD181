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
        generationVolume = 0.4f;

        arrowGeneration = GameObject.Find("SpawnPoint").GetComponent<ArrowGeneration>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        source.GetOutputData(volumeCheck, 0);
        if (Mathf.Abs(volumeCheck[0]) > generationVolume)
        {
            if (timer >= 1)
            {
                arrowGeneration.ArrowSpawn();
                Debug.Log("Generate Arrow Now");
                timer = 0;
            }
        }
    }
}
