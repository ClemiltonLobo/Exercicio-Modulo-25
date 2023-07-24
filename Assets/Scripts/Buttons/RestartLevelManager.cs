using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevelManager : MonoBehaviour
{
    public void RestartLevel()
    {
        int lastLevelIndex = PlayerPrefs.GetInt("LastLevelIndex");
        SceneManager.LoadScene(lastLevelIndex);
    }
}