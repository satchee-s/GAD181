using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private bool isPressed = false;
    void Update()
    {
        if (isPressed == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("Left arrow pressed");
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("Right arrow pressed");
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("Up arrow pressed");
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("Down arrow pressed");
            }
        }

    }
    
}
