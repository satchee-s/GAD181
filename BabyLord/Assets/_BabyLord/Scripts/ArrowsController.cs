using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsController : MonoBehaviour
{
    public Forcefield forcefield;
    public Scoring scoring;
    public EnemyController enemy;
    PlayerController player;

    public KeyCode KeyToPress;
    public KeyCode AltKey;
    public bool canBePressed; //buttons pressed on trigger with player   
    float timer = 10f;
    float increaseFieldSize = 0.2f;
    float reduceFieldSize = -0.2f;
    void Start()
    {
        forcefield = GameObject.Find("Forcefield").GetComponent<Forcefield>();
        scoring = GameObject.Find("Forcefield").GetComponent<Scoring>();
        enemy = GameObject.Find("GameController").GetComponent<EnemyController>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        transform.position -= new Vector3(enemy.arrowSpeed * Time.deltaTime, 0f, 0f);//moves the arrows per frame on the x axis
        if (Input.GetKeyDown(KeyToPress))
        {
            if (canBePressed)
            {
                ArrowPressed();
            }
        }
        if (Input.GetKeyDown(AltKey))
        {
            if (canBePressed)
            {
                ArrowPressed();
            }
        }

        if (player.activeEnemy == false)
        {
            Destroy(GameObject.FindWithTag("Arrows"));
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
            forcefield.ChangeSize(reduceFieldSize);
            scoring.ChangeScore(-1); //changes the score
        }
    }
    void ArrowPressed()
    {
        forcefield.ChangeSize(increaseFieldSize);
        scoring.ChangeScore(1); //changes the score
        gameObject.SetActive(false); //destroys the gameobject when an arrow key is pressed
    }
}
