using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ScreenCapture.CaptureScreenshot("D:");
        }
    }
}
