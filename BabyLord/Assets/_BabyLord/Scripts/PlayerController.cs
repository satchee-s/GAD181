using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    EnemyController enemy;
    public bool activeEnemy;
    private int fightCount;
    private Vector2 position = new Vector2(10f, 0);
    private bool isPressed = false;

    private void Start()
    {
        enemy = GameObject.Find("GameController").GetComponent<EnemyController>();
        activeEnemy = false;
        fightCount = 1;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (activeEnemy == false && fightCount < 5)
            {
                enemy.SetEnemyValues(Random.Range(0, 3));
                activeEnemy = true;
                Instantiate(enemy.currentEnemy, position, Quaternion.identity);
                Debug.Log("Enemy number " + fightCount);
                fightCount++;
            }

            if (activeEnemy == false && fightCount == 5)
            {
                enemy.SetEnemyValues(3);
                Debug.Log("Enemy number " + fightCount);
                Instantiate(enemy.currentEnemy, position, Quaternion.identity);
                activeEnemy = true;
            }
        }
    }
}

