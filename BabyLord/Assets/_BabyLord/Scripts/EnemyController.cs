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
    public bool activePowerup = false;
    float timer = 10f;
    bool powerupCalled = false;

    private void Update()
    {
        if (activePowerup == true)
        {
            timer -= Time.deltaTime;
            if (powerupCalled == false)
            {
                RiflePowerup();
                powerupCalled = true;
            }
            if (timer <= 0)
            {
                RiflePowerup();
                activePowerup = false;
                powerupCalled = false;
            }
        }
    }

    public void SetEnemyValues (int enemy)
    {
        if (enemy == (int)enemyType.Pistol)
        {
            arrowSpeed = 11f;
            coolDown = 0.5f;
            spawnRange = false;
            currentEnemy = pistol;
        }
        else if (enemy == (int)enemyType.SMG)
        {
            arrowSpeed = 8.5f;
            coolDown = 0.6f;
            spawnRange = true;
            currentEnemy = SMG;
        }
        else if (enemy == (int)enemyType.Rifle)
        {
            arrowSpeed = 15f;
            coolDown = 0.7f;
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

    public void RiflePowerup()
    {
        if (powerupCalled == false)
        {
            arrowSpeed = arrowSpeed - 3f;
            coolDown = coolDown + 0.3f;
            Debug.Log(arrowSpeed + ", " + coolDown);
        }
        if (powerupCalled == true)
        {
            arrowSpeed = arrowSpeed + 3f;
            coolDown = coolDown - 0.3f;
            activePowerup = false;
            Debug.Log("Rifle powerup deactivated");
        }
    }
}
