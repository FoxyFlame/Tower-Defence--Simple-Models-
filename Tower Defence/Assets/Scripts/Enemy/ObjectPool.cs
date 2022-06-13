using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject _enemyObject;
    [SerializeField] int _poolSize = 10;
    [SerializeField] [Range(0f, 5f)] public float _spawnTimer = 2f;

    float _waitTimeBetwenWaves = 15f;

    WaveMenager _waveMenager;
    LokateTarget[] _lokateTargets;

    GameObject[] _pool;

    int _countOfCreatedEnemies = 0;

    void Awake()
    {
        PopulatePool();

    }
    void Start()
    {
        _lokateTargets = FindObjectsOfType<LokateTarget>();
    }

    void OnEnable()
    {
        _waveMenager = FindObjectOfType<WaveMenager>();
        StartCoroutine(EnemyLoopForLevel());
    }
    void PopulatePool()
    {
        _pool = new GameObject[_poolSize];

        for (int i = 0; i < _pool.Length; i++)
        {
            _pool[i] = Instantiate(_enemyObject, transform);
            _pool[i].SetActive(false);
        }
    }

    IEnumerator EnemyLoopForLevel()
    {
        while(true)
        {
            int _maxEnemies = _waveMenager.GetMaxEnemiesByWave();

            if (_countOfCreatedEnemies >= _maxEnemies && _maxEnemies != null)
            {
                ResetEnemiesCount();
                yield return new WaitForSeconds(_waitTimeBetwenWaves);
                _waveMenager.NewWave();
            }

            EnableObjectInPool();

            yield return new WaitForSeconds(_spawnTimer);
        }
    }

    void EnableObjectInPool()
    {
        for(int i = 0; i < _pool.Length; i++)
        {
            if(_pool[i].activeInHierarchy == false)
            {
                _pool[i].SetActive(true);
                _waveMenager.WavesOptions();
                _countOfCreatedEnemies++;
                return;
            }
        }
    }

    public void ResetEnemiesCount()
    {
        _countOfCreatedEnemies = 0;
    }
}
