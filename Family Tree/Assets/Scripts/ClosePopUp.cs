using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePopUp : MonoBehaviour
{
    public void close()
    {
        gameObject.SetActive(false);
        GameObject[] bands = GameObject.FindGameObjectsWithTag("Band");
        foreach (GameObject g in bands)
        {
            g.GetComponent<BandID>().clickable = true;
        }
        GameObject[] musicians = GameObject.FindGameObjectsWithTag("Musician");
        foreach (GameObject g in musicians)
        {
            g.GetComponent<MemberID>().clickable = true;
        }
    }
}
