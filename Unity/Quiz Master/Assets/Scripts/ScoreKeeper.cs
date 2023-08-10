using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int correctAnswers = 0;
    int questionsSeen = 0;

    public int GetCorrectAnswers() 
    {
        return correctAnswers;
    }

    public void IncrementCorrectAnswers()
    { 
        correctAnswers += 1;
    }

    public int GetQuestionsSeen()
    {
        return correctAnswers;
    }

    public void IncrementQuestionsSeen()
    { 
        questionsSeen += 1;
    }

    public int CalculateScore()
    { 
        return Mathf.RoundToInt(correctAnswers / (float)questionsSeen * 100);
    }
}
