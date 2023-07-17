using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 3.5f;
    [SerializeField]
    private GameObject _explosionPrefab;

    private Player _player;
    private SpawnManager _spawnManager;
    private AudioSource _audioSource;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        if (_player == null)
        {
            Debug.LogError("The Player is NULL.");
        }

        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        if (_player == null)
        {
            Debug.LogError("The Spawn Manager is NULL.");
        }

        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("The Audio Source is NULL.");
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.transform.tag)
        {
            case "Laser":
                _audioSource.Play(0);
                _player.AddPointsToScore(50);

                Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
                _spawnManager.StartSpawning();
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                break;
            case "Player":
                _audioSource.Play(0);
                _player.SufferDamage();

                Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                break;
        }
    }
}
