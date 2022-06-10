using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject _enemyObject;
    [SerializeField] int _poolSize = 10;
    [SerializeField] [Range(0f, 5f)] float _spawnTimer = 2f;

    float _waitTimeBetwenWaves = 15f;

    WaveMenager _waveMenager;
    LokateTarget[] _lokateTargets;

    GameObject[] _pool;

    bool _toogleCreateNewEnemies = true;
    int _countOfCreatedEnemies = 0;

    void Awake()
    {
        PopulatePool();
    }
    void Start()
    {
        _waveMenager = FindObjectOfType<WaveMenager>();
        _lokateTargets = FindObjectsOfType<LokateTarget>();
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
        EnableObjectInPool();
        Debug.Log("Wykonuje");
        if (_countOfCreatedEnemies >= _waveMenager.GetMaxEnemiesByWave())
        {
            _waveMenager.NewWave();
            ResetEnemiesCount();
            ToogleCreateNewEnemies();
            Debug.Log("Czekam");
            yield return new WaitForSeconds(_waitTimeBetwenWaves);
            ToogleCreateNewEnemies();
            Debug.Log("Poczeka³em");
        }

        yield return new WaitForSeconds(_spawnTimer);
    }

    void EnableObjectInPool()
    {
        for(int i = 0; i < _pool.Length; i++)
        {
            if(_pool[i].activeInHierarchy == false)
            {
                _pool[i].SetActive(true);
                Debug.Log(_countOfCreatedEnemies);
                _countOfCreatedEnemies++;
                return;
            }
        }
    }

    public void ResetEnemiesCount()
    {
        _countOfCreatedEnemies = 0;
    }

    void ToogleCreateNewEnemies()
    {
        _toogleCreateNewEnemies = !_toogleCreateNewEnemies;
    }

    public bool GetToogleCreateNewEnemies()
    {
        return _toogleCreateNewEnemies;
    }
}
