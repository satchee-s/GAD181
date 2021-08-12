using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public int[] powerType = { 0, 1, 2 };
    public ArrowsController arrows;
    public Scoring scoring;
    void Start()
    {
        scoring = GameObject.Find("Forcefield").GetComponent<Scoring>();
        arrows = GameObject.Find("GameController").GetComponent<ArrowsController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void powerups(int powerupType)
    {
        if (powerupType == 0)
        {
            scoring.Multiplyscore();
        }
        else if (powerupType == 1)
        {
            arrows.ffscalef = 0.4f;
        }
        else if (powerupType == 2)
        {
            arrows.ffscalef =(arrows.ffscalef * 1.25f);
        }
    }
}
