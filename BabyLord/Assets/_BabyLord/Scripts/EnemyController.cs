using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int[] enemyType = { 0, 1, 2, 3 };
    public float arrowSpeed;
    public float coolDown;
    public bool spawnRange;
    public GameObject pistol;
    public GameObject SMG;
    public GameObject rifle;
    public GameObject boss;
    public GameObject currentEnemy;

    public void SetEnemyValues (int enemy)
    {
        if (enemy == 0)
        {
            arrowSpeed = 9f;
            coolDown = 0.7f;
            spawnRange = false;
            currentEnemy = pistol;
        }
        else if (enemy == 1)
        {
            arrowSpeed = 8f;
            coolDown = 0.6f;
            spawnRange = true;
            currentEnemy = SMG;
        }
        else if (enemy == 2)
        {
            arrowSpeed = 17f;
            coolDown = 0.7f;
            spawnRange = false;
            currentEnemy = rifle;
        }
        else if (enemy == 3)
        {
            arrowSpeed = 11.7f;
            coolDown = 0.513f;
            spawnRange = true;
            currentEnemy = boss;
        }
    }
}
