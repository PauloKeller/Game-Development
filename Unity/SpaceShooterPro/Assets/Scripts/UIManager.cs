using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _bestScoreText;
    [SerializeField]
    private Image _liveImage;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _restartText;
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private GameObject _pauseMenu;
    private GameManager _gameManager;

    private int _bestScore;
    private void Start()
    {
        _scoreText.text = "Score: 0";

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError("The Game Manager is NULL.");
        }

        _bestScore = PlayerPrefs.GetInt("BEST_SCORE", 0);
        UpdateBestScoreLabel();
    }

    private void UpdateBestScoreLabel() {
        _bestScoreText.text = $"Best: {_bestScore}";
    }

    public void UpdateScoreLabel(int score) {
        _scoreText.text = $"Score: {score}";

        if (score > _bestScore) {
            _bestScore = score ;
            PlayerPrefs.SetInt("BEST_SCORE", _bestScore);
        }
    }

    public void UpdateLivesSprite(int currentLives) {
        _liveImage.sprite = _liveSprites[currentLives];
    }
    public void ShowGameOver() {
        UpdateBestScoreLabel();
        _gameOverText.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
        _gameManager.GameOver();
        StartCoroutine(FlickerTextDurationRoutine());
    }

    IEnumerator FlickerTextDurationRoutine()
    {
        while (true) {
            _gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void ShowPauseMenu()
    {
        _pauseMenu.SetActive(true);
        Animator animator = _pauseMenu.GetComponent<Animator>();
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        animator.SetBool("IsPaused", true);
        PauseGame();
    }

    public void HidePauseMenu() 
    {
        _pauseMenu.SetActive(false);
        ResumeGame();
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
