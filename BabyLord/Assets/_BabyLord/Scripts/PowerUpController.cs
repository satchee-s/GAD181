using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{   
    public enum PowerUp { Pistol, SMG, Rifle};
    public int currentPowerup;
    public bool riflePowerup = false;
    public bool pistolPowerup = false;
    public bool smgPowerup = false;
    public GameObject pistolIcon;
    public GameObject smgIcon;
    public GameObject rifleIcon;
    public GameObject currentIcon;
    Vector2 position = new Vector2(-7, -5);

    public void SetPowerup (int type)
    {
        if (type == (int)PowerUp.Pistol)
        {
            pistolPowerup = true;
            currentIcon = pistolIcon;
            Instantiate(currentIcon, position, Quaternion.identity);
        }
        else if (type == (int)PowerUp.SMG)
        {
            smgPowerup = true;
            currentIcon = smgIcon;
            Instantiate(currentIcon, position, Quaternion.identity);
        }
        else if (type == (int)PowerUp.Rifle)
        {
            riflePowerup = true;
            currentIcon = rifleIcon;
            Instantiate(currentIcon, position, Quaternion.identity);
        }
    }
}
