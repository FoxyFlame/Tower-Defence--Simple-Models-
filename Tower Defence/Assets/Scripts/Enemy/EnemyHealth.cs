using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _maxHealth = 5;
    int _currentHealth = 0;

    void OnEnable()
    {
        _currentHealth = _maxHealth;
    }

    void OnParticleCollision(GameObject other)
    {
        AfterHit();
    }

    void AfterHit()
    {
        _currentHealth--;

        if(_currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
