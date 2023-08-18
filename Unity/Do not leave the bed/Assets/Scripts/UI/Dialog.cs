using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField]
    GameObject textPanel;

    [SerializeField]
    GameObject gameOverPanel;

    [SerializeField]
    TextMeshProUGUI dialogText;

    [SerializeField]
    GameObject winGamePanel;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) 
        {
            DismissDialogBox();
        }
    }

    public void ShowDialogText(string text) 
    {
        textPanel.SetActive(true);
        dialogText.text = text;
    }

    public void DismissDialogBox()
    {
        textPanel.SetActive(false);
    }

    public void ShowGameOver() 
    {
        gameOverPanel.SetActive(true);
    }

    public void ShowWinGame()
    {
        winGamePanel.SetActive(true);
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    { 
        Application.Quit();
    }
}
