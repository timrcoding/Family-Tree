using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeTree : MonoBehaviour
{
    [HideInInspector]
    public ShowTools st;
    [HideInInspector]
    public PlayCassette pc;

    public bool resizeable;
    public bool big;

    private void Awake()
    {
        st = GameObject.FindObjectOfType<ShowTools>();
        pc = GameObject.FindObjectOfType<PlayCassette>();
        big = false;
        resizeable = true;
    }

    public void resize()
    {
        {
            if (resizeable)
            {
                
                if (!big)
                {
                    pc.cassAudio.PlayOneShot(pc.mapSound);
                    GetComponent<Animator>().SetTrigger("Expand");
                }
                else
                {
                    pc.cassAudio.PlayOneShot(pc.mapSound);
                    GetComponent<Animator>().SetTrigger("Shrink");

                }
                
            }
        }
    }

    public void makeBigFalse()
    {
        big = false;
        
    }
    public void makeBigTrue()
    {
        big = true;

    }
}
