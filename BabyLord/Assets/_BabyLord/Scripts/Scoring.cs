using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Text ScoreText;
    private int score = 0;
    int multiplier = 1;
    //float timer;
    public void ChangeScore(int scoreBonus)
    {
        score = score+(scoreBonus*multiplier);
        ScoreText.text = "Score: " + score.ToString();
    }
    public void MultiplyScore(bool consecutiveArrow, float timer)
    {
        int counter = 0;
        timer -= Time.deltaTime;
        if (consecutiveArrow == true && timer > 0)
        {
            counter++;
            if (counter == 3)
            {
                multiplier = (int)(multiplier + 0.5);
                counter = 0;
            }
        }
    }
}
