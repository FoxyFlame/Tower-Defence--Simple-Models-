using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _maxHealth = 5;
    [SerializeField] int _currentHealth = 0;

    Enemy _enemy;
    void OnEnable()
    {
        _currentHealth = _maxHealth;
    }

    void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        AfterHit();
    }

    public int GetCurrentHealth()
    {
        return _currentHealth;
    }

    void AfterHit()
    {
        _currentHealth--;

        if(_currentHealth <= 0)
        {
            gameObject.SetActive(false);
            _enemy.RewardGold();
        }
    }
}
