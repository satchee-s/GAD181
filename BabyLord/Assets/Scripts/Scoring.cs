using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Text ScoreText;
    private int score;
    //public static Scoring instance;
    private void Start()
    {
        score = 0;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<ArrowsController>() != null)
        {
            score++;
            IsScored();
        }
        
    }

    public void IsScored()
    {
        
        ScoreText.text = "Score: " + score.ToString();
    }
}
