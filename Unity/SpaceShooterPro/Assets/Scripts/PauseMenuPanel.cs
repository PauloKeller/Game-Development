using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuPanel : MonoBehaviour
{
    private UIManager _uiManager;
  
    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL.");
        }
    }
    public void LoadMainMenu() 
    {
        SceneManager.LoadScene(0);
    }

    public void Resume() 
    {
        _uiManager.HidePauseMenu();
    }
}
