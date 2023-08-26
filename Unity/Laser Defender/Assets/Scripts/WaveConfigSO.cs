using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimerVariance = 1f;
    [SerializeField] float minimumSpawnTime = 0.2f;

    public int EnemyCount 
    {
        get 
        { 
            return enemyPrefabs.Count;
        }
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public Transform StartingWaypoint 
    {
        get 
        {
            return pathPrefab.GetChild(0);
        }
    }

    public List<Transform> Waypoints
    {
        get 
        { 
            List<Transform> result = new List<Transform>();
            foreach (Transform child in pathPrefab)
            { 
                result.Add(child);
            }
            return result;
        }
    }

    public float MoveSpeed 
    {
        get 
        {
            return moveSpeed;
        }
    }

    public float RandomSpawnTime
    {
        get 
        {
            float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimerVariance, 
                timeBetweenEnemySpawns + spawnTimerVariance);
            return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
        }
    }
}
