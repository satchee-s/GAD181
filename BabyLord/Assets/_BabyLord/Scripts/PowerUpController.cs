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
    Vector2 position = new Vector2(-7, 4);

    public void SetPoweup (int type)
    {
        if (type == (int)PowerUp.Pistol)
        {
            pistolPowerup = true;
            Instantiate(pistolIcon, position, Quaternion.identity);
        }
        else if (type == (int)PowerUp.SMG)
        {
            smgPowerup = true;
            Instantiate(smgIcon, position, Quaternion.identity);
        }
        else if (type == (int)PowerUp.Rifle)
        {
            riflePowerup = true;
            Instantiate(rifleIcon, position, Quaternion.identity);
        }
    }
}
