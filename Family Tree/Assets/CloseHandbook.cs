using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseHandbook : MonoBehaviour
{
    public IdentifyMember im;

    private void Awake()
    {
        im = GameObject.FindObjectOfType<IdentifyMember>();
    }
    public void close()
    {
        im.notebook.SetActive(false);
    }
}
