using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMenager : MonoBehaviour
{
    [SerializeField] int _maxWave = 7;
    [SerializeField] int _currentWave;

    ObjectPool _objectPool;
    EnemyHealth[] _enemyHealths;

    int _maxEnemiesCountByWawe;
    int _newMaxHealth;

    void Start()
    {
        _objectPool = FindObjectOfType<ObjectPool>();
        _enemyHealths = FindObjectsOfType<EnemyHealth>();
        _currentWave = 1;
        WavesOptions();
    }

    void WavesOptions()
    {
        if(_currentWave > _maxWave)
        {
            // U WIN GAME
        }

        switch (_currentWave)
        {
            case 1:              
                _maxEnemiesCountByWawe = 10;
                _newMaxHealth = 5;
                break;
            case 2:
                _maxEnemiesCountByWawe = 15;
                break;
            case 3:
                _maxEnemiesCountByWawe = 15;
                _newMaxHealth = 7;
                break;
            case 4:
                _maxEnemiesCountByWawe = 20;
                break;
            case 5:
                _maxEnemiesCountByWawe = 25;
                break;
            case 6:
                _maxEnemiesCountByWawe = 25;
                _newMaxHealth = 10;
                break;
            case 7:
                _maxEnemiesCountByWawe = 5;
                _newMaxHealth = 25;
                break;
        }

        foreach(EnemyHealth _enemyHealth in _enemyHealths)
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
        return _maxEnemiesCountByWawe;
    }
}
