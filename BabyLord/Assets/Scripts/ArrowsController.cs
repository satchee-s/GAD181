using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsController : MonoBehaviour
{
    public KeyCode KeyToPress;
    public float beatSpeed = 6f;
    //private bool hasStarted; when the arrows scrolling starts
    private bool canBePressed; //buttons pressed on trigger with player

    private GameObject[] arrowPrefabs;
    private float spawnTime;
    public float spawnFrequency = 1f;
    private GameObject newArrow;
    private Vector2 initialArrowPosition = new Vector2(10, 0);
    public GameObject leftArrow;
    public GameObject rightArrow;
    public GameObject upArrow;
    public GameObject downArrow;
    
    void Start()
    {
        //beatSpeed = beatSpeed / 60f; ----how fast the arrows will move (2 units per second aka 2 music beats) 
        arrowPrefabs = new GameObject[4];
        arrowPrefabs[0] = leftArrow;
        arrowPrefabs[1] = rightArrow;
        arrowPrefabs[2] = upArrow;
        arrowPrefabs[3] = downArrow;
    }

    void Update()
    {
        /*if (!hasStarted)
        {
            //press enter key if scrolling hasn't started yet
           if (Input.GetKeyDown(KeyCode.Return))
           {
                  hasStarted = true; ------ removed this because you have to press enter a new arrow is generated
           }
        }*/

        transform.position -= new Vector3(beatSpeed * Time.deltaTime, 0f, 0f); //moves the arrows per frame on the x axis

        if (Input.GetKeyDown(KeyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false); //destroys the gameobject when a arrow key is pressed
            }
        }
       
        ArrowSpawning();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        canBePressed = true;  //when an arrow enter the player's collider offset 
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        canBePressed = false; //when an arrow exists the player's collider offset, it's destroyed
        if (other.gameObject.name == "Player")
        {
            DestroyOnMissHit();
        }
    }

    private void ArrowSpawning()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime >= spawnFrequency)
        {
            int arrowType = Random.Range(0, 3);
            newArrow = arrowPrefabs[arrowType];
            Instantiate(newArrow, initialArrowPosition, Quaternion.identity); //new arrow is generated at the starting point
            spawnTime = 0;
            //Debug.Log("Arrow was spawned at " + arrowCount);
        }  
    }
    void DestroyOnMissHit()
    {
        Destroy(this.gameObject);
    }
}
