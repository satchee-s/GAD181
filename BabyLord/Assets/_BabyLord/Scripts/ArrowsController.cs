using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsController : MonoBehaviour
{
    public Forcefield forcefield;
    public Scoring scoring;

    public KeyCode KeyToPress;
    public float beatSpeed = 6f;
    public bool canBePressed; //buttons pressed on trigger with player

   /* private float spawnTime;
    public float spawnFrequency = 1f;
    private GameObject newArrow;*/

   
    
    void Start()
    {
        forcefield = GameObject.Find("Forcefield").GetComponent<Forcefield>();
        scoring = GameObject.Find("Forcefield").GetComponent<Scoring>();

    }

    void Update()
    {

        transform.position -= new Vector3(beatSpeed * Time.deltaTime, 0f, 0f); //moves the arrows per frame on the x axis

        if (Input.GetKeyDown(KeyToPress))
        {
            if (canBePressed)
            {
                forcefield.ChangeSize(0.1f);
                scoring.ChangeScore(); //changes the score
                gameObject.SetActive(false); //destroys the gameobject when a arrow key is pressed
            }
        }
        //ArrowSpawning();
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

   /* */
}
