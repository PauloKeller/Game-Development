using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 3.0f;
    private float _fireCooldown = -1f;

    private Player _player;
    private Animator _animator;
    private float _deathAnimationDuration = 2.8f;
    private AudioSource _audioSource;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        if (_player == null)
        {
            Debug.LogError("The Player is NULL.");
        }

        _animator = GetComponent<Animator>();
        if (_animator == null)
        {
            Debug.LogError("The Animator is NULL.");
        }

        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("The Audio Source is NULL.");
        }
    }
    void Update()
    {
        CalculateMoviment();
        Fire();
    }

    void Fire() 
    {
        if (Time.time > _fireCooldown) 
        {
            _fireRate = Random.Range(3f, 7f);
            _fireCooldown = Time.time + _fireRate;
            GameObject enemyLaser = Instantiate(_laserPrefab, transform.position, Quaternion.identity);
            Laser[] lasers = enemyLaser.GetComponentsInChildren<Laser>();
            foreach (Laser laser in lasers) {
                laser.AssignEnemyLaser();
            }
        }
    }

    void CalculateMoviment() 
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -5f)
        {
            float randomX = Random.Range(-8f, 8f);
            transform.position = new Vector3(randomX, 7, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.transform.tag)
        {
            case "Laser":
                _audioSource.Play(0);
                Destroy(other.gameObject);
                _player.AddPointsToScore(10);
                _speed = 0;
                _animator.SetTrigger("OnEnemyDeath");

                GetComponent<Collider2D>().enabled = false;

                Destroy(this.gameObject, _deathAnimationDuration);
                break;
            case "Player":
                _audioSource.Play(0);
                _player.SufferDamage();

                GetComponent<Collider2D>().enabled = false;

                _speed = 0;
                _animator.SetTrigger("OnEnemyDeath");
                Destroy(this.gameObject, _deathAnimationDuration);
                break;
        }
    }
}
