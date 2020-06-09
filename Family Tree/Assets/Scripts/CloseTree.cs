using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTree : MonoBehaviour
{
    [HideInInspector]
    public ShowTools st;
    void Start()
    {
        st = GameObject.FindObjectOfType<ShowTools>();
    }

    private void OnMouseDown()
    {
        Debug.Log("CLOSE");
        st.closeTree();
    }
}
