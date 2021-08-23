using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPowerup : MonoBehaviour
{
    PlayerController player;
    Forcefield forcefield;
    Scoring scoring;
    PowerUpController powerUp;
    ArrowsController arrows;
    float timer = 30f;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        forcefield = GameObject.Find("Forcefield").GetComponent<Forcefield>();
        scoring = GameObject.Find("Forcefield").GetComponent<Scoring>();
        powerUp = GameObject.Find("PowerupSpawner").GetComponent<PowerUpController>();
        arrows = GameObject.Find("GameController").GetComponent<ArrowsController>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (player.activeEnemy == true)
            {
                PowerupChecker();
                Destroy(gameObject);
            }
        }
    }

    void PowerupChecker()
    {
        if (powerUp.pistolPowerup == true)
        {
            forcefield.PistolPowerup();
            powerUp.pistolPowerup = false;
        }
        else if (powerUp.smgPowerup == true)
        {
            scoring.activeMultiplier = true;
            powerUp.smgPowerup = false;
        }
        else if (powerUp.riflePowerup == true)
        {
            arrows.enemy.activePowerup = true;
            powerUp.riflePowerup = false;
        }
    }
}
