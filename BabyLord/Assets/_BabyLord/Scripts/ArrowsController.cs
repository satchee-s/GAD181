using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsController : MonoBehaviour
{
    public Forcefield forcefield;
    public Scoring scoring;
    public EnemyController enemy;
    PowerUpController powerUp;

    public KeyCode KeyToPress;
    //public float beatSpeed;
    public bool canBePressed; //buttons pressed on trigger with player   
    public float ffscalef = 0.03f;
    bool arrowHit = false;
    float timer = 30f;
    void Start()
    {
        forcefield = GameObject.Find("Forcefield").GetComponent<Forcefield>();
        scoring = GameObject.Find("Forcefield").GetComponent<Scoring>();
        enemy = GameObject.Find("GameController").GetComponent<EnemyController>();
        powerUp = GameObject.Find("PowerupSpawner").GetComponent<PowerUpController>();
    }
    void Update()
    {
        //beatSpeed = enemy.arrowSpeed;
        transform.position -= new Vector3(enemy.arrowSpeed * Time.deltaTime, 0f, 0f); //moves the arrows per frame on the x axis
        if (Input.GetKeyDown(KeyToPress))
        {
            if (canBePressed)
            {
                ArrowPressed();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PowerupChecker();
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
            forcefield.ChangeSize(ffscalef*-1);
            scoring.ChangeScore(-1); //changes the score
            arrowHit = false;
        }
    }
    void ArrowPressed()
    {
        forcefield.ChangeSize(ffscalef);
        scoring.ChangeScore(1); //changes the score
        gameObject.SetActive(false); //destroys the gameobject when an arrow key is pressed
        arrowHit = true;
    }
    void PowerupChecker()
    {
        if (powerUp.pistolPowerup == true)
        {
            forcefield.PistolPowerup();
            powerUp.pistolPowerup = false;
        }
        if (powerUp.smgPowerup == true)
        {
            scoring.MultiplyScore(arrowHit, timer);
            powerUp.smgPowerup = false;
        }
        if (powerUp.riflePowerup == true)
        {
            RiflePowerup(timer);
            powerUp.riflePowerup = false;
        }
    }
    void RiflePowerup(float checkTime)
    {
        checkTime -= Time.deltaTime;
        while (timer > 0)
        {
            ffscalef = 0.2f;
        }
    }

}
