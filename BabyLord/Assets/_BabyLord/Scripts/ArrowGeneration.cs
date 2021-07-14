using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGeneration : MonoBehaviour
{
    private GameObject[] arrowPrefabs;
    public GameObject leftArrow;
    public GameObject rightArrow;
    public GameObject upArrow;
    public GameObject downArrow;

    private float spawnTime = 0;
    public float spawnFrequency = 5f;
    private GameObject newArrow;
    private Vector2 initialArrowPosition = new Vector2(10, 0);

    private void Start()
    {
        arrowPrefabs = new GameObject[4];
        arrowPrefabs[0] = leftArrow;
        arrowPrefabs[1] = rightArrow;
        arrowPrefabs[2] = upArrow;
        arrowPrefabs[3] = downArrow;
    }
    private void Update()
    {
        ArrowSpawn();
    }

    private void ArrowSpawn()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime >= spawnFrequency)
        {
            int arrowType = Random.Range(0, 4);
            newArrow = arrowPrefabs[arrowType];
            Instantiate(newArrow, initialArrowPosition, Quaternion.identity); //new arrow is generated at the starting point
            spawnTime = 0;
        }
    }
}
