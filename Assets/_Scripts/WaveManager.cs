using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] List<WaveData> waves;
    [SerializeField] int currentWaveId;
    [SerializeField] float spawnTimer;
    [SerializeField] float waveTimer;
    [SerializeField] WaveData currentWave;
    [SerializeField] BoxCollider2D spawnArea;

    void Start()
    {
        UpdateWave();
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;   
        waveTimer -= Time.deltaTime;   

        if(spawnTimer <= 0)
        {
            EnemySpawn();
            spawnTimer = currentWave.SpawnRate;
        }
    }

    public void UpdateWave()
    {
        currentWaveId++;
        currentWave = waves[currentWaveId];
        spawnTimer = currentWave.SpawnRate;
        waveTimer = currentWave.WaveTime;
    }

    public void EnemySpawn()
    {
        Vector3 spawnPoint = new Vector3(
                Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
                Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
            );
        Instantiate(currentWave.WaveWeights[0].EnemyType.Prefab, spawnPoint, Quaternion.identity);
    } 
}



