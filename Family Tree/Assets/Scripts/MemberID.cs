using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemberID : MonoBehaviour
{
    [HideInInspector]
    public GameResources gr;
    [HideInInspector]
    public IdentifyMember im;

    public int refId;
    public bool clickable;
    public bool firstTimeSelected;

    public bool specifiedMusician;
    //REFERENCES LIST OF MUSICIANS
    public GameObject musicianNameText;
    public int musicianID;
    public string musicianName;
    //REFERENCES LIST OF INSTRUMENTS
    public GameObject musicianInstrumentText;
    public int instrumentID;
    public string instrumentName;

    public Image backgroundColor;

    public int proposedID;
    public int proposedInstrument;

    public bool correctlyIdentified;

    private void Awake()
    {
        gr = GameObject.FindObjectOfType<GameResources>();
        im = GameObject.FindObjectOfType<IdentifyMember>();
        clickable = true;
        firstTimeSelected = true;
    }
    void Start()
    {
        musicianName = gr.musicianNames[musicianID].ToString();
        instrumentName = gr.musicianInstruments[instrumentID].ToString();
    }

    private void OnMouseDown()
    {
        if (clickable)
        {
            im.notebook.SetActive(true);
            im.musicianRef = refId;
            if (!firstTimeSelected)
            {
                im.musicianIdentified(proposedID);
                im.instrumentIdentified(proposedInstrument);
            }
            else
            {
                firstTimeSelected = false;
            }

            GameObject[] musicians = GameObject.FindGameObjectsWithTag("Musician");
            foreach (GameObject g in musicians)
            {
                g.GetComponent<MemberID>().clickable = false;
            }
        }
    }
}
