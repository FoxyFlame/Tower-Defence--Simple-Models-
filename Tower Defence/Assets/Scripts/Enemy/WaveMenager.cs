using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMenager : MonoBehaviour
{
    [SerializeField] int _maxWave = 7;
    [SerializeField] int _currentWave = 1;

    ObjectPool _objectPool;
    EnemyHealth[] _enemyHealths;

    int _maxEnemiesCountByWave = 10;
    int _newMaxHealth = 5;

    void Start()
    {
        _objectPool = FindObjectOfType<ObjectPool>();
        WavesOptions();
    }

    public void WavesOptions()
    {
        _enemyHealths = FindObjectsOfType<EnemyHealth>();

        if (_currentWave > _maxWave)
        {
            // U WIN GAME
        }

        switch (_currentWave)
        {
            case 1:
                _maxEnemiesCountByWave = 10;
                _newMaxHealth = 5;
                Debug.Log(_maxEnemiesCountByWave + " " + _newMaxHealth);
                break;
            case 2:
                _maxEnemiesCountByWave = 15;
                _objectPool._spawnTimer = 1.5f;
                break;
            case 3:
                _maxEnemiesCountByWave = 15;
                _newMaxHealth = 7;
                break;
            case 4:
                _maxEnemiesCountByWave = 20;
                break;
            case 5:
                _maxEnemiesCountByWave = 25;
                break;
            case 6:
                _maxEnemiesCountByWave = 25;
                _newMaxHealth = 10;
                break;
            case 7:
                _maxEnemiesCountByWave = 5;
                _newMaxHealth = 25;
                break;
        }

        foreach (EnemyHealth _enemyHealth in _enemyHealths)
        {
            _enemyHealth.SetNewMaxHealth(_newMaxHealth);
        }
    }

    public void NewWave()
    {
        _currentWave++;
        WavesOptions();
    }

    public int GetMaxEnemiesByWave()
    {
        int _temp = _maxEnemiesCountByWave;
        return _temp;
    }
}
