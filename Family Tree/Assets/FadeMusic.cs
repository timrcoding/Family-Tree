using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMusic : MonoBehaviour
{
    [HideInInspector]
    public PlayCassette pc;
    public AudioSource audioS;

    public void Awake()
    {
        pc = GameObject.FindObjectOfType<PlayCassette>();
    }
    
}
