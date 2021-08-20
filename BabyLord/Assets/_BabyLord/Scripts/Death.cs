using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    PlayerController player;
    ButtonController button;
    EnemyController enemy;
    PowerUpController power;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        button = GameObject.Find("Button").GetComponent<ButtonController>();
        enemy = GameObject.Find("GameController").GetComponent<EnemyController>();
        power = GameObject.Find("PowerupSpawner").GetComponent<PowerUpController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Forcefield"))
        {
            Destroy(gameObject);
            player.activeEnemy = false;
            button.playState = false;
            button.source.isPaused();
            //activate respective powerup
        }
    }

    void ActivatePowerUp()
    {
        if (player.fightCount < 5)
        {
            power.SetPoweup(player.enemyType);
        }
    }
}
