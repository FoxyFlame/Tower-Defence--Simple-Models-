using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMenager : MonoBehaviour
{
    public void LoadNextLevel()
    {
        int _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(_currentSceneIndex + 1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
