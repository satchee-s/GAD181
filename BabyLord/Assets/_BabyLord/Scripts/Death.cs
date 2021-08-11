using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    PlayerController player;
    ButtonController button;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        button = GameObject.Find("Button").GetComponent<ButtonController>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Forcefield"))
        {
            Destroy(gameObject);
            player.activeEnemy = false;
            button.playState = false;
            button.source.isPaused();
        }
    }
}
