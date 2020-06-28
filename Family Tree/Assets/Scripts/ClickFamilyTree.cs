using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFamilyTree : MonoBehaviour
{
    [HideInInspector]
    public ShowTools st;

    public bool resizeable;
    public bool bigSmall;

    private void Awake()
    {
        st = GameObject.FindObjectOfType<ShowTools>();
    }

    private void OnMouseDown()
    {
        if (resizeable)
        {
            resizeable = !resizeable;
            GetComponent<Animator>().SetBool("Expand", bigSmall);
        }
    }

    public void allowResizing()
    {
        resizeable = true;
        bigSmall = !bigSmall;
    }
}
