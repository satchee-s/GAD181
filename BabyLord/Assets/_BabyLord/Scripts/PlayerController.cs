using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    EnemyController enemy;
    WinLose win;

    public bool activeEnemy;
    public int fightCount;
    private Vector2 position = new Vector2(10.5f, 0);
    private bool isPressed = false;
    public int enemyType;

    private void Start()
    {
        enemy = GameObject.Find("GameController").GetComponent<EnemyController>();
        win = GameObject.Find("GameController").GetComponent<WinLose>();

        activeEnemy = false;
        fightCount = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (activeEnemy == false && fightCount < 5)
            {
                win.Resume();
                win.PowerUpText(3);
                enemyType = (Random.Range(0, 3));
                enemy.SetEnemyValues(enemyType);
                activeEnemy = true;
                Instantiate(enemy.currentEnemy, position, Quaternion.identity);
                fightCount++;
            }

            if (activeEnemy == false && fightCount == 5)
            {
                win.Resume();
                win.PowerUpText(3);
                enemyType = 3;
                enemy.SetEnemyValues(enemyType);
                Instantiate(enemy.currentEnemy, position, Quaternion.identity);
                activeEnemy = true;
            }
        }
    }
}

