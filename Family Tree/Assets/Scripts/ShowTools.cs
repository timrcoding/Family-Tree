using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTools : MonoBehaviour
{
    public GameObject familyTree;
    public GameObject treeRef;
    public GameObject notebook;
    public void showFamilyTree()
    {
        familyTree.SetActive(true);
        treeRef.SetActive(false);
    }

    public void closeTree()
    {
        Debug.Log("CLOSE");
        familyTree.SetActive(false);
        treeRef.SetActive(true);
    }
}
