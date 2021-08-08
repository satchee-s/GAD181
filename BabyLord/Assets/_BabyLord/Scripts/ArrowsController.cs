using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsController : MonoBehaviour
{
    public Forcefield forcefield;
    public Scoring scoring;

    public KeyCode KeyToPress;
    public float beatSpeed = 9f;
    public bool canBePressed; //buttons pressed on trigger with player   
    
    void Start()
    {
        forcefield = GameObject.Find("Forcefield").GetComponent<Forcefield>();
        scoring = GameObject.Find("Forcefield").GetComponent<Scoring>();
    }

    void Update()
    {
        beatSpeed = Random.Range(9f, 13f);
        //Debug.Log(beatSpeed);
        transform.position -= new Vector3(beatSpeed * Time.deltaTime, 0f, 0f); //moves the arrows per frame on the x axis

        if (Input.GetKeyDown(KeyToPress))
        {
            if (canBePressed)
            {
                forcefield.ChangeSize(0.07f);
                scoring.ChangeScore(); //changes the score
                gameObject.SetActive(false); //destroys the gameobject when a arrow key is pressed
            }
        }
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
        if (other.gameObject.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }
        canBePressed = false; //when an arrow exists the player's collider offset, it's destroyed
        
        if (other.gameObject.CompareTag("Forcefield") && this.gameObject.activeSelf == true)
        {
            forcefield.ChangeSize(-0.07f);
        }
        
    }
}
