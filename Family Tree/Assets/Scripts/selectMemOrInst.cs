using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectMemOrInst : MonoBehaviour
{
    [HideInInspector]
    public IdentifyMember im;
    [HideInInspector]
    public GameResources gr;
    public int idNumber;
    

    private void Awake()
    {
        im = GameObject.FindObjectOfType<IdentifyMember>(); 
        gr = GameObject.FindObjectOfType<GameResources>(); 

        
    }

    private void OnMouseDown()
    {
        Debug.Log(gameObject.name);
        if(this.tag == "Name")
        {
            im.musicianIdentified(idNumber);
        }
        else
        {
            im.instrumentIdentified(idNumber);
        }
    }
}
