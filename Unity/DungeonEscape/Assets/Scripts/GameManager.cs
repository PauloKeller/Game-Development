using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("GameManager is null");
            }

            return _instance;
        }
    }
    public bool HasKeyToCastle { get; set; }
    public Player Player { get; private set; }

    private void Awake()
    {
        _instance = this;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void AddGems(int amount)
    {
        Player.diamonds += amount;
        UIManager.Instance.UpdateGemCount(Player.diamonds);
    }
}
