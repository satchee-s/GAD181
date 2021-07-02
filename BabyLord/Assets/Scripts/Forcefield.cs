using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcefield : MonoBehaviour
{
    public GameObject player;
    public void ChangeSize(float scaleFactor)
    {
        if (transform.localScale.x >= 0.2f)// <- if the forcefield hits the player when it reaches 0.1
        {
            transform.localScale = new Vector2(transform.localScale.x + scaleFactor, transform.localScale.y + scaleFactor);
        }
        else
        {
            Destroy(player);
        }

        //changes the size of the forcefield depending on whether the arrow was hit or missed
    }
}
