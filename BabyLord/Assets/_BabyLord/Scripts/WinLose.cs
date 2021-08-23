using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    public Text WinningText;
    public Text PwrText;
    [SerializeField] GameObject winMenu;
    bool loseGame = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (loseGame == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void WinText(bool wonGame, bool bossFight)
    {

        winMenu.SetActive(true);
        if (wonGame == true && bossFight == false)
        {
            WinningText.text = "You won!" + "\n" + "Press enter to continue";
        }
        else if (wonGame == false)
        {
            WinningText.text = "You lost :(" + "\n" + "Press enter to restart";
            loseGame = true;
        }
        else if (wonGame == true && bossFight == true)
        {
            WinningText.text = "You won!" + "\n" + "Press enter to restart";
            loseGame = true;
        }
    }

    public void PowerUpText(int powerupType)
    {
        if (powerupType == 0)
        {
            PwrText.text = "You got the pistol powerup!" + "\n" + "Gives your force field a boost" + "\n" + "Press E to activate";
        }
        else if (powerupType == 1)
        {
            PwrText.text = "You got the SMG powerup!" + "\n" + "Temporarily increases your score multiplier" + "\n" + "Press E to activate";
        }
        else if (powerupType == 2)
        {
            PwrText.text = "You got the rifle powerup!" + "\n" + "Temporarily slows down the speed of enemy attacks" + "\n" + "Press E to activate";
        }
        else if (powerupType == 3)
            PwrText.text = "  ";
    }

    public void Resume()
    {
        winMenu.SetActive(false);
    }


}