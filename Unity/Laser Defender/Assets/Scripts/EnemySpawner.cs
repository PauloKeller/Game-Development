using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 1f;
    [SerializeField] bool isLooping = true;

    WaveConfigSO currentWave;

    void Start()
    {
        StartCoroutine(SpawnEnemieWavesCoroutine());   
    }

    public WaveConfigSO CurrentWave 
    {
        get 
        { 
            return currentWave;
        }
    }

    IEnumerator SpawnEnemieWavesCoroutine()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int index = 0; index < currentWave.EnemyCount; index++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(index),
                    currentWave.StartingWaypoint.position,
                    Quaternion.Euler(0, 0, 180),
                    transform);
                    yield return new WaitForSeconds(currentWave.RandomSpawnTime);
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
        
    }
}
