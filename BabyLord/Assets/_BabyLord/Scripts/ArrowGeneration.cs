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
    private GameObject newArrow;
    private Vector2 initialArrowPosition = new Vector2(10f, 0); //sets the point where arrows are spawned

    //public float beatSpeed = 10f;

    Collider2D forceCollider;
    Vector3 colliderSize;

    EnemyController enemy;

    private void Start()
    {
        arrowPrefabs = new GameObject[4]; //creates an array containing each type of arrow
        arrowPrefabs[0] = leftArrow;
        arrowPrefabs[1] = rightArrow;
        arrowPrefabs[2] = upArrow;
        arrowPrefabs[3] = downArrow;

        forceCollider = GameObject.Find("Forcefield").GetComponent<Collider2D>();
        enemy = GameObject.Find("GameController").GetComponent<EnemyController>();
    }

    public void ArrowSpawn()
    {
        YRange();
        int arrowType = Random.Range(0, 4); //picks a random type of arrow
        newArrow = arrowPrefabs[arrowType];
        Instantiate(newArrow, initialArrowPosition, Quaternion.identity); //new arrow is generated at the starting point
    }
    
    void YRange()
    {
        if (enemy.spawnRange == true)
        {
            colliderSize = forceCollider.bounds.extents; // gets the size of the force field collider
            initialArrowPosition.y = Random.Range((colliderSize.y * -1) + 1, colliderSize.y - 1); //sets the newly generated arrow position anywhere on the y axis within reach of the forcefield
        }
        else if (enemy.spawnRange == false)
        {
            initialArrowPosition.y = 0f;
        }
    }
}
