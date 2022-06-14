using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public bool CreateTower(Tower _tower, Vector3 _position)
    {
        Bank _bank = FindObjectOfType<Bank>();

        if(_bank == null)
        {
            return false;
        }

        if(_bank._CurrentBalance >= _bank.GetCostOfNewTower())
        {
            Instantiate(_tower, _position, Quaternion.identity);
            _bank.WidrawForTower();
            return true;
        }

        return false;
    }

}
