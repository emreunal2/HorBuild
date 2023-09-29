using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WaveData
{
    [SerializeField] string waveName;
    [SerializeField] float waveTime;
    [SerializeField] float spawnRate;
    [SerializeField] WaveWeights[] waveWeights;

    public string WaveName { get => waveName; set => waveName = value; }
    public float WaveTime { get => waveTime; set => waveTime = value; }
    public float SpawnRate { get => spawnRate; set => spawnRate = value; }
    public WaveWeights[] WaveWeights { get => waveWeights; set => waveWeights = value; }
}

[Serializable]
public class WaveWeights
{
    [SerializeField] EnemyTypeSO enemyType;
    [SerializeField] float weight;
    [SerializeField] int test;
    public EnemyTypeSO EnemyType { get => enemyType; set => enemyType = value; }
    public float Weight { get => weight; set => weight = value; }
}
