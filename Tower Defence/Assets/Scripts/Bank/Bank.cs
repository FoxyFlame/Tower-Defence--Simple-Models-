using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int _startingBalance = 100;
    [SerializeField] int _costOfTower = 25;
    [SerializeField] int _currentBalance;
    [SerializeField] TextMeshProUGUI _displayBalance;
    [SerializeField] TextMeshProUGUI _displayCostOfNewTower;

    int _costRiseForNextTower = 45;

    private void Awake()
    {
        _currentBalance = _startingBalance;
        UpdateDisplayBalance();
    }

    public int _CurrentBalance { get { return _currentBalance; } }

    public void Deposit(int _amount)
    {
        _currentBalance += Mathf.Abs(_amount);
        UpdateDisplayBalance();
    }

    public void Widraw(int _amount)
    {
        _currentBalance -= Mathf.Abs(_amount);
        UpdateDisplayBalance();


        if (_currentBalance < -100)
        {
            //Loose the game
            ReloadScene();
        }
    }

    public void WidrawForTower()
    {
        Widraw(_costOfTower);
        _costOfTower += _costRiseForNextTower;
        UpdateDisplayBalance();
    }

    public int GetCostOfNewTower()
    {
        return _costOfTower;
    }

    void ReloadScene()
    {
        Scene _currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(_currentScene.buildIndex);
    }

    void UpdateDisplayBalance()
    {
        _displayBalance.text = "Gold: " + _currentBalance.ToString();
        _displayCostOfNewTower.text = "New Tower Cost: " + _costOfTower;
    }
}
