using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _rewardForKill = 20;
    [SerializeField] int _stealMoneyByEnemy = 45;

    Bank _bank;

    void Start()
    {
        _bank = FindObjectOfType<Bank>();
    }

    public void RewardGold()
    {   
        if(_bank == null) { return; }
        _bank.Deposit(_rewardForKill);
    }

    public void StealGold()
    {
        if (_bank == null) { return; }
        _bank.Widraw(_stealMoneyByEnemy);
    }
}
