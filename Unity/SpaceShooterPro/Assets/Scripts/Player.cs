using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private float _speedMultiplier = 2.0f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _shieldVisualizer;
    [SerializeField]
    private GameObject _leftEngineVisualizer;
    [SerializeField]
    private GameObject _rightEngineVisualizer;
    [SerializeField]
    private int _score;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private float _fireRate = 0.15f;
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private float _fireOffSet = 1.05f;
    [SerializeField]
    private float _tripleShotDuration = 5.0f;
    [SerializeField]
    private float _speedBoostDuration = 5.0f;
    [SerializeField]
    private AudioClip _laserSoundClip;
    [SerializeField]
    private AudioClip _explosionSoundClip;

    private AudioSource _audioSource;
    private float _canFire = -1f;
    private SpawnManager _spawnManager;
    private UIManager _uiManager;
    private bool _tripleShotIsEnabled = false;
    private bool _speedBoostIsEnabled = false;
    private bool _shieldIsEnabled = false;
    private GameManager _gameManager;

    void Start()
    {
        
        _spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        if (_spawnManager == null) 
        {
            Debug.LogError("The Spawn Manager is NULL.");
        }

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL.");
        }

        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("The Audio Source is NULL.");
        }
        else 
        {
            _audioSource.clip = _laserSoundClip;
        }

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError("The Game Manager is NULL.");
        }

        if (!_gameManager.isCoop)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
    void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        if (_speedBoostIsEnabled)
        {
            transform.Translate(direction * _speed * Time.deltaTime);
        }
        else 
        {
            transform.Translate(direction * _speed * Time.deltaTime);
        }

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 6f), 0);

        if (transform.position.y >= 6f)
        {
            transform.position = new Vector3(transform.position.x, 6f, 0);
        }
        else if (transform.position.y <= -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }


        if (transform.position.x >= 10f)
        {
            transform.position = new Vector3(-10f, transform.position.y, 0);
        }
        else if (transform.position.x <= -10f)
        {
            transform.position = new Vector3(10f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
        _audioSource.Play(0);

        if (_tripleShotIsEnabled)
        {
            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        }
        else {
            _canFire = Time.time + _fireRate;
            Instantiate(_laserPrefab, transform.position + new Vector3(0, _fireOffSet, 0), Quaternion.identity);
        }
    }

    public void SufferDamage()
    {
        if (_shieldIsEnabled)
        {
            _shieldIsEnabled = false;
            _shieldVisualizer.SetActive(false);
            return;
        }

        if (_lives > 0)
        {
            _lives--;
            _uiManager.UpdateLivesSprite(_lives);
        }

        switch (_lives) {
            case 2:
                _leftEngineVisualizer.SetActive(true);
                break;
            case 1:
                _rightEngineVisualizer.SetActive(true);
                break;
            default:
                _audioSource.clip = _explosionSoundClip;
                _audioSource.Play(0);
                _spawnManager.OnPlayerDeath();
                _uiManager.ShowGameOver();
                Destroy(this.gameObject);
                break;
        }
    }

    public void ToggleTripleShotPowerup() 
    {
        _tripleShotIsEnabled = true;
        StartCoroutine(TripleShotDurationRotine());
    }

    IEnumerator TripleShotDurationRotine()
    {
        yield return new WaitForSeconds(_tripleShotDuration);
        _tripleShotIsEnabled = false;
    }

    public void ToggleSpeedBoostPowerup()
    {
        _speedBoostIsEnabled = true;
        StartCoroutine(SpeedBoostDurationRotine());
    }

    IEnumerator SpeedBoostDurationRotine() 
    {
        _speed *= _speedMultiplier;
        yield return new WaitForSeconds(_speedBoostDuration);
        _speedBoostIsEnabled = false;
        _speed /= _speedMultiplier;
    }

    public void ToggleShieldPowerup()
    {
        _shieldIsEnabled = true;
        _shieldVisualizer.SetActive(true);
    }
    public void AddPointsToScore(int points) 
    { 
        _score += points;
        _uiManager.UpdateScoreLabel(_score);
    }
}
