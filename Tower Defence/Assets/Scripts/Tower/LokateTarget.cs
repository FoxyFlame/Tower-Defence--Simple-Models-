using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LokateTarget : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] Transform _weapon;
    [SerializeField] ParticleSystem _projectParticles;
    [SerializeField] float _towerRange = 2f;

    bool _enemyAreDestroyed = false;
    void Update()
    {
        FindClosestTarget();
        AimWeaponToTarget();
    }

    private void FindClosestTarget()
    {
        Enemy[] _enemies = FindObjectsOfType<Enemy>();
        Transform _closestTarget = null;
        float _maxDistance = Mathf.Infinity;
        float _actualDistance = Mathf.Infinity;
        float _targetDistance = 0;

        foreach (Enemy _enemy in _enemies)
        {
            _targetDistance = Vector3.Distance(transform.position, _enemy.transform.position);

            if (_targetDistance < _maxDistance)
            {
                _closestTarget = _enemy.transform;
                _maxDistance = _targetDistance;
            }
        }

        if(!_target)
        {
            _target = _closestTarget;
        }

        _actualDistance = Vector3.Distance(transform.position, _target.position);
        //Debug.Log(_target.GetComponent<EnemyPathMover>().enabled); jak zmienic target jak go pokona

        if (_actualDistance > _towerRange || _enemyAreDestroyed)
        {
            _target = _closestTarget;
            AreEnemyDestroyed(false);
            Debug.Log("Ready for new target");
        }
    }

    void AimWeaponToTarget()
    {
        //if(!_target) { return; }

        float _targetDistance = Vector3.Distance(transform.position, _target.position);

        _weapon.LookAt(_target);

        if(_targetDistance < _towerRange)
        {
            AttactWhenTarget(true);
        }
        else
        {
            AttactWhenTarget(false);
        }
    }

    void AttactWhenTarget(bool _isActive)
    {
        var _emissionModule = _projectParticles.emission;
        _emissionModule.enabled = _isActive;
    }

    public void AreEnemyDestroyed(bool _enemyEgzistance)
    {
        _enemyAreDestroyed = _enemyEgzistance;
    }
}
