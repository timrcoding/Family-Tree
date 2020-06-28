using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ScoringSingleton ss;
    public bool[] musicianCorrect;
    public int[] musiciansInRound;
    public string[] proposedNames;

    private void Awake()
    {
        ss = GameObject.FindObjectOfType<ScoringSingleton>();
    }

    private void Start()
    {
        
    }
    
}
