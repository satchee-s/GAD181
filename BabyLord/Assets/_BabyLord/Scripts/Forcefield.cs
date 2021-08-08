using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcefield : MonoBehaviour
{
    public GameObject player; 
    public void ChangeSize(float scaleFactor)
    {
        if (transform.localScale.x >= 0.5f)// <- if the forcefield hits the player when it reaches 0.3
        {
            transform.localScale = new Vector2(transform.localScale.x + scaleFactor, transform.localScale.y + scaleFactor);
        }
        else
        {
            Destroy(player);
        }
    }
}
