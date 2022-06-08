using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LokateTarget : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] Transform _weapon;

    void Start()
    {
        _target = FindObjectOfType<EnemyPathMover>().transform;
    }

    void Update()
    {
        AimWeaponToTarget();
    }
    void AimWeaponToTarget()
    {
        _weapon.LookAt(_target.transform.position);
    }
}