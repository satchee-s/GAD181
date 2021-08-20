using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    enum enemyType {Pistol, SMG, Rifle, Boss};
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
        if (enemy == (int)enemyType.Pistol)
        {
            arrowSpeed = 11f;
            coolDown = 0.4f;
            spawnRange = false;
            currentEnemy = pistol;
        }
        else if (enemy == (int)enemyType.SMG)
        {
            arrowSpeed = 8.5f;
            coolDown = 0.5f;
            spawnRange = true;
            currentEnemy = SMG;
        }
        else if (enemy == (int)enemyType.Rifle)
        {
            arrowSpeed = 18f;
            coolDown = 0.55f;
            spawnRange = false;
            currentEnemy = rifle;
        }
        else if (enemy == (int)enemyType.Boss)
        {
            arrowSpeed = 13f;
            coolDown = 0.513f;
            spawnRange = true;
            currentEnemy = boss;
        }
    }
}
