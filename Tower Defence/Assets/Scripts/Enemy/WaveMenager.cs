using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveMenager : MonoBehaviour
{
    [SerializeField] int _maxWave = 7;
    [SerializeField] int _currentWave = 1;

    ObjectPool _objectPool;
    EnemyHealth[] _enemyHealths;
    EnemyPathMover[] _enemyPathMovers;

    int _maxEnemiesCountByWave = 10;
    int _newMaxHealth = 5;
    float _newSpeed = 1f;

    void Start()
    {
        _objectPool = FindObjectOfType<ObjectPool>();
        WavesOptions();
    }

    public void WavesOptions()
    {
        _enemyHealths = FindObjectsOfType<EnemyHealth>();
        _enemyPathMovers = FindObjectsOfType<EnemyPathMover>();

        MenuInfininiteWorking();

        ChangeScene();

        switch (_currentWave)
        {
            case 1:
                _maxEnemiesCountByWave = 10;
                _newMaxHealth = 5;
                Debug.Log("1");
                break;
            case 2:
                _maxEnemiesCountByWave = 15;
                _objectPool._spawnTimer = 1.5f;
                Debug.Log("2");
                break;
            case 3:
                _maxEnemiesCountByWave = 15;
                _newMaxHealth = 7;
                Debug.Log("3");
                break;
            case 4:
                _maxEnemiesCountByWave = 20;
                _newSpeed = 1.75f;
                Debug.Log("5");
                break;
            case 5:
                _maxEnemiesCountByWave = 25;
                _objectPool._spawnTimer = 1.25f;
                Debug.Log("6");
                break;
            case 6:
                _maxEnemiesCountByWave = 25;
                _newMaxHealth = 10;
                break;
            case 7:
                _maxEnemiesCountByWave = 3;
                _newMaxHealth = 100;
                _newSpeed = 0.75f;
                _objectPool._spawnTimer = 2f;
                break;
            default:
                _maxEnemiesCountByWave = 10;
                _newMaxHealth = 5;
                _newSpeed = 1f;
                _objectPool._spawnTimer = 2f;
                break;
        }

        foreach (EnemyHealth _enemyHealth in _enemyHealths)
        {
            _enemyHealth.SetNewMaxHealth(_newMaxHealth);
        }

        foreach (EnemyPathMover _enemyPathMover in _enemyPathMovers)
        {
            _enemyPathMover.SetNewSpeed(_newSpeed);
        }
    }

    private void ChangeScene()
    {
        if (_currentWave > _maxWave)
        {
            int _currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
            int _nextSceneIndex = _currentLevelIndex + 1;

            if (_nextSceneIndex > SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(0);
                return; //U WIN GAME RETURN MENU
            }
            else
            {
                SceneManager.LoadScene(_nextSceneIndex);
            }
        }
    }

    private void MenuInfininiteWorking()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            _currentWave = 1;
            return;
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
