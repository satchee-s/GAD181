using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    PlayerController player;
    private ButtonController button;
    EnemyController enemy;
    PowerUpController power;
    WinLose win;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        button = GameObject.Find("GameController").GetComponent<ButtonController>();
        enemy = GameObject.Find("GameController").GetComponent<EnemyController>();
        power = GameObject.Find("PowerupSpawner").GetComponent<PowerUpController>();
        win = GameObject.Find("GameController").GetComponent<WinLose>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Forcefield"))
        {
            EnemyDeath();
        }
    }

    void ActivatePowerUp()
    {
        if (player.fightCount <= 5)
        {
            power.SetPowerup(player.enemyType);
            win.PowerUpText(player.enemyType);
        }
    }

    void EnemyDeath()
    {
        if (player.enemyType < 3)
        {
            win.WinText(true, false);
        }
        else if (player.enemyType == 3)
        {
            win.WinText(true, true);
            win.PowerUpText(3);
        }
        Destroy(gameObject);
        player.activeEnemy = false;
        button.playState = false;
        button.source.isPaused();
        ActivatePowerUp();

    }
}

