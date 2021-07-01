using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcefield : MonoBehaviour
{
    public void ChangeSize(float scaleFactor)
    {
        transform.localScale = new Vector2(transform.localScale.x + scaleFactor, transform.localScale.y + scaleFactor);
        //changes the size of the forcefield depending on whether the arrow was hit or missed
    }
}
