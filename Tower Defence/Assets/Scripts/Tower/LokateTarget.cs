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

    ObjectPool _objectPool;

    void Start()
    {
        _objectPool = FindObjectOfType<ObjectPool>();
    }

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
        float _targetDistance;

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
        else
        {
            _actualDistance = Vector3.Distance(transform.position, _target.position);
        }

        if (_actualDistance > _towerRange || _target.GetComponent<EnemyHealth>().GetCurrentHealth() <= 0)
        {
            _target = _closestTarget;
        }
    }

    void AimWeaponToTarget()
    {
        if (_target != null)
        {
            float _targetDistance = Vector3.Distance(transform.position, _target.position);

            _weapon.LookAt(_target);

            if (_targetDistance < _towerRange)
            {
                AttactWhenTarget(true);
            }
            else
            {
                AttactWhenTarget(false);
            }
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
}
