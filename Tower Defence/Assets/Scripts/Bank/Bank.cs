using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int _startingBalance = 150;
    [SerializeField] int _currentBalance;

    private void Awake()
    {
        _currentBalance = _startingBalance;
    }

    public int _CurrentBalance { get { return _currentBalance; } }

    public void Deposit(int _amount)
    {
        _currentBalance += Mathf.Abs(_amount);
    }

    public void Widraw(int _amount)
    {
        _currentBalance -= Mathf.Abs(_amount);

        if (_currentBalance < 0)
        {
            //Loose the game
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        Scene _currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(_currentScene.buildIndex);
    }
}
