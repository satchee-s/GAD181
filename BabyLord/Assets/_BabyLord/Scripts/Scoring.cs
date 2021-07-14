using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Text ScoreText;
    private int score = 0;

    public void ChangeScore()
    {
        score++;
        ScoreText.text = "Score: " + score.ToString();
    }
}
