using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _maxHealth = 5;
    [SerializeField] int _currentHealth = 0;

    LokateTarget _lokateTarget;

    void OnEnable()
    {
        _currentHealth = _maxHealth;
        _lokateTarget = GetComponent<LokateTarget>();
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
            _lokateTarget.AreEnemyDestroyed(true); // ????
        }
    }
}
