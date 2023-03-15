using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Managing spawning of enemies for a wave, as well as how long the wave should last.
/// This works alongside the LevelManager.
/// </summary>

public class WaveManager : MonoBehaviour
{
    [Header("Enemy info")]
    public GameObject[] enemyTypes;
    public Transform[] spawnPoints;

    [Header("Wave Settings")]
    public int maxNumberAtOnce;
    public int maxNumberOverAll;

    public bool isActive;
    public bool isComplete;

    public float timeBetweenSpawns;
    float timer;

    List<GameObject> enemiesSpawned = new List<GameObject>();
    List<GameObject> currentEnemiesSpawned = new List<GameObject>();

    [HideInInspector]
    public int killed;

    public UnityEvent EndWave;

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenSpawns)
            {
                AttemptToSpawn();
                timer = 0;
            }
        }
    }
    void AttemptToSpawn()
    {
        // Pick enemy type
        int type = Random.Range(0, enemyTypes.Length);

        // Pick the position
        int pos = Random.Range(0, spawnPoints.Length);

        // Check if you can spawn
        if(enemiesSpawned.Count < maxNumberOverAll && currentEnemiesSpawned.Count < maxNumberAtOnce)
        {
            GameObject currentEnemy = Instantiate(enemyTypes[type], spawnPoints[pos].position, Quaternion.identity);
            currentEnemy.GetComponent<EnemyHealthFromSpawner>().manager = this;
            enemiesSpawned.Add(currentEnemy);
            currentEnemiesSpawned.Add(currentEnemy);
        }
    }
    public void KillEnemy(GameObject enemy)
    {
        killed++;
        currentEnemiesSpawned.Remove(enemy);
        if (currentEnemiesSpawned.Count == 0 && enemiesSpawned.Count >= maxNumberOverAll)
        {
            isActive = false;
            isComplete = true;
            EndWave.Invoke();
        }
    }
}
