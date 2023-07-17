using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject[] _powerups;
    [SerializeField]
    private float _enemySpawnTime = 1f;

    private bool _keepSpawning = true;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError("The Game Manager is NULL.");
        }
    }

    public void StartSpawning() 
    {
        StartCoroutine(SpawnEnemyRotine());
        StartCoroutine(SpawnPowerupRotine());
    }

    IEnumerator SpawnEnemyRotine() 
    {
        while (_keepSpawning) 
        {
            yield return new WaitForSeconds(1.0f);
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(_enemySpawnTime);
        }
    }

    IEnumerator SpawnPowerupRotine()
    {
        while (_keepSpawning)
        {
            yield return new WaitForSeconds(3.0f);
            float spawnTime = Random.Range(3f, 7f);
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            int powerupIndex = Random.Range(0, 3);
            Instantiate(_powerups[powerupIndex], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }

    public void OnPlayerDeath() 
    { 
        _keepSpawning = false;
    }
}
