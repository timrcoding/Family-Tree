using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleLevelLoad : MonoBehaviour
{
     public void loadScene(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void deactivate()
    {
        gameObject.SetActive(false);
    }

    public void clearScore()
    {
        PlayerPrefs.SetInt("CorrectCount", 0);
    }
}
