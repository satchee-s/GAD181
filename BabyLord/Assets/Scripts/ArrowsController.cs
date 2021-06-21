using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsController : MonoBehaviour
{
    public KeyCode KeyToPress;
    private float beatSpeed = 120;
    private bool hasStarted; //when the arrows scrolling starts
    private bool canBePressed; //buttons pressed on trigger with player
    
    void Start()
    {
        beatSpeed = beatSpeed / 60f;
        //how fast the arrows will move (2 units per second aka 2 music beats)
    }

    void Update()
    {
        if (!hasStarted)
        {
            //press enter key if scrolling hasn't started yet
            if (Input.GetKeyDown(KeyCode.Return))
            {
                hasStarted = true;
            }
        }
        else
        {
            transform.position -= new Vector3(beatSpeed * Time.deltaTime, 0f, 0f);
            //moves the arrows per frame on the x axis
        }
        if (Input.GetKeyDown(KeyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false); //destroys the gameobject when a arrow key is pressed
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        canBePressed = true;  //when an arrow enter the player's collider offset 
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        canBePressed = false; //when an arrow exists the player's collider offset, button can't be pressed
    }
}
