using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Text ScoreText;
    private int score = 0;
    int multiplier = 1;
    float gameTime = 10f;
    public bool activeMultiplier = false;

    private void Update()
    {
        if (activeMultiplier == true)
        {
            gameTime -= Time.deltaTime;
            if (gameTime > 0)
            {
                multiplier = 3;
                //Debug.Log("Score multiplier: " + multiplier);
            }
            if (gameTime <= 0)
            {
                activeMultiplier = false;
                multiplier = 1;
                //Debug.Log("Score multiplier: " + multiplier);
            }
        }
    }
    public void ChangeScore(int scoreBonus)
    {
        score = score+(scoreBonus*multiplier);
        ScoreText.text = "Score: " + score.ToString();
    }
}
