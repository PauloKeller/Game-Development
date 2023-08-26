using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    int score = 0;
    static ScoreKeeper instance;
    public ScoreKeeper Instance { get { return instance; } }

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int Score {
        get { return score; }
    }

    public void ClearScore()
    {
        score = 0;
    }

    public void AddScore(int points)
    {
        score += points;
        Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log(score);
    }
}
