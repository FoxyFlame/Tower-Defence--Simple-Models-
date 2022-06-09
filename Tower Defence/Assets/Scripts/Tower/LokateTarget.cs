using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LokateTarget : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] Transform _weapon;

    void Start()
    {
        //FndNewTarget();
    }

    void Update()
    {
        AimWeaponToTarget();
    }
    void AimWeaponToTarget()
    {
        if(_target == null)
        {
            FindNewTarget();
        }
        _weapon.LookAt(_target.transform.position);
    }

    void FindNewTarget()
    {
        _target = FindObjectOfType<EnemyPathMover>().transform;
    }
}
