using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsController : MonoBehaviour
{
    public Forcefield forcefield;

    public KeyCode KeyToPress;
    public float beatSpeed = 6f;
    private bool canBePressed; //buttons pressed on trigger with player

    private float spawnTime;
    public float spawnFrequency = 1f;
    private GameObject newArrow;
    private Vector2 initialArrowPosition = new Vector2(10, 0);

    private GameObject[] arrowPrefabs;
    public GameObject leftArrow;
    public GameObject rightArrow;
    public GameObject upArrow;
    public GameObject downArrow;
    
    void Start()
    {
        arrowPrefabs = new GameObject[4];
        arrowPrefabs[0] = leftArrow;
        arrowPrefabs[1] = rightArrow;
        arrowPrefabs[2] = upArrow;
        arrowPrefabs[3] = downArrow;

        forcefield = GameObject.Find("Forcefield").GetComponent<Forcefield>();
    }

    void Update()
    {

        transform.position -= new Vector3(beatSpeed * Time.deltaTime, 0f, 0f); //moves the arrows per frame on the x axis

        if (Input.GetKeyDown(KeyToPress))
        {
            if (canBePressed)
            {
                forcefield.ChangeSize(0.1f);
                gameObject.SetActive(false); //destroys the gameobject when a arrow key is pressed
            }
        }
        ArrowSpawning();
    }


   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Forcefield"))
        {
            canBePressed = true;  //when an arrow enter the player's collider offset
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        canBePressed = false; //when an arrow exists the player's collider offset, it's destroyed
        Debug.Log("Arrow missed");
        Destroy(gameObject);
        if (other.gameObject.CompareTag("Forcefield") && this.gameObject.activeSelf == true)
        {
            forcefield.ChangeSize(-0.1f);
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
        }
    }
}
