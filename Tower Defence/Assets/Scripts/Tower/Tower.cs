using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int _costOfTower = 75;

    public bool CreateTower(Tower _tower, Vector3 _position)
    {
        Bank _bank = FindObjectOfType<Bank>();

        if(_bank == null)
        {
            return false;
        }

        if(_bank._CurrentBalance >= _costOfTower)
        {
            Instantiate(_tower, _position, Quaternion.identity);
            _bank.Widraw(_costOfTower);
            return true;
        }

        return false;
    }

}
