using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidChangeScene : MonoBehaviour
{
    public float timer;
    public float stopPoint;

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= stopPoint)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
