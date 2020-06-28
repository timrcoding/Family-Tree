using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BandID : MonoBehaviour
{
    [HideInInspector]
    public GameResources gr;

    public int bandID;
    public List<string> bandInfo;
    public bool clickable;
    public GameObject bandText;
    public GameObject bandName;
    public GameObject bandDates;

    public List<string> nonSpecifiedMusicians;
    public List<string> nonSpecifiedInstruments;

    private void Awake()
    {
        gr = GameObject.FindObjectOfType<GameResources>();
        clickable = true;
    }

    private void Start()
    {
        readTextAsset();
        bandText.GetComponent<TextMeshProUGUI>().text = bandInfo[2];
    }

    private void OnMouseDown()
    {
        if (clickable)
        {
            
            gr.popUp.SetActive(true);
            gr.bandName.GetComponent<TextMeshProUGUI>().text = bandInfo[0];
            gr.dates.GetComponent<TextMeshProUGUI>().text = bandInfo[1];
            gr.TextBody.GetComponent<TextMeshProUGUI>().text = bandInfo[2];

            GameObject[] bands = GameObject.FindGameObjectsWithTag("Band");
            foreach (GameObject g in bands)
            {
               // g.GetComponent<BandID>().clickable = false;
            }
            GameObject[] musicians = GameObject.FindGameObjectsWithTag("Musician");
            foreach (GameObject g in musicians)
            {
                g.GetComponent<MemberID>().clickable = true;
            }
        }
    }

    void readTextAsset()
    {
        bandInfo = new List<string>(gr.bandInfo[bandID].text.Split('\n'));
    }

    
}
