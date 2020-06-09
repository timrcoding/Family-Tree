using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFamilyTree : MonoBehaviour
{
    [HideInInspector]
    public ShowTools st;

    private void Awake()
    {
        st = GameObject.FindObjectOfType<ShowTools>();
    }

    private void OnMouseDown() => st.showFamilyTree();
}
