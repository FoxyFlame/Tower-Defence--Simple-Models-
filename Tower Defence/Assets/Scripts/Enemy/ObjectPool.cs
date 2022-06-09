using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject _enemyObject;
    [SerializeField] int _poolSize = 5;
    [SerializeField] [Range(0f, 5f)] float _spawnTimer = 2f;

    GameObject[] _pool;

    bool _toogleCreateNewEnemies = true;

    void Awake()
    {
        PopulatePool();
    }
    void Start()
    {
        StartCoroutine(EnemyLoopForLevel());
    }

    void PopulatePool()
    {
        _pool = new GameObject[_poolSize];

        for(int i = 0; i < _pool.Length; i++)
        {
            _pool[i] = Instantiate(_enemyObject, transform);
            _pool[i].SetActive(false);
           
        }
    }

    IEnumerator EnemyLoopForLevel()
    {
        while (_toogleCreateNewEnemies)
        {
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
                return;
            }
        }
    }
}
