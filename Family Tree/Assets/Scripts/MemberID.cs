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
    [HideInInspector]
    public ShowTools st;
    [HideInInspector]
    public ResizeTree rt;
    [HideInInspector]
    public ScoringSingleton ss;
    [HideInInspector]
    public PlayCassette pc;

    public int refId;
    public bool clickable;
    public bool firstTimeSelected;
    public bool alreadyCounted;
    public bool confirmed;
    public Color[] backgroundColor;
    public GameObject background;

    
    
    //REFERENCES LIST OF MUSICIANS
    public GameObject musicianNameText;
    public int musicianID;
    public string musicianName;
    //REFERENCES LIST OF INSTRUMENTS
    public GameObject musicianInstrumentText;
    public int instrumentID;
    public string instrumentName;

    public GameObject musicianBandText;
    public string band;

    public int proposedID;
    public string proposedIDName;
    public int proposedInstrument;
    public string proposedInstrumentName;

    public bool correctlyIdentified;
    public bool prevCorrectlyIdentified;

    private void Awake()
    {
        gr = GameObject.FindObjectOfType<GameResources>();
        im = GameObject.FindObjectOfType<IdentifyMember>();
        st = GameObject.FindObjectOfType<ShowTools>();
        rt = GameObject.FindObjectOfType<ResizeTree>();
        ss = GameObject.FindObjectOfType<ScoringSingleton>();
        pc = GameObject.FindObjectOfType<PlayCassette>();


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
        if (clickable && !confirmed)
        {
            pc.cassAudio.PlayOneShot(pc.mapSound);
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
                g.GetComponent<MemberID>().GetComponent<BoxCollider2D>().enabled = false;
            }
            GameObject[] band = GameObject.FindGameObjectsWithTag("Band");
            foreach (GameObject g in band)
            {
                g.GetComponent<BandID>().GetComponent<BoxCollider2D>().enabled = false;
            }
            rt.resizeable = false;
            gr.popUp.SetActive(false);
        }
    }

    public void checkForId()
    {
            
            if (musicianID == proposedID)
            {
                correctlyIdentified = true;
                prevCorrectlyIdentified = true;
                ss.checkForCorrectAnswers();
            }
            else
            {
                correctlyIdentified = false;
            if (prevCorrectlyIdentified)
            {
                wipeIncorrectAnswer(refId);
                prevCorrectlyIdentified = false;
            }
                ss.checkForCorrectAnswers();
            }
        }
        
    public void setColour()
    {
        if (confirmed)
        {
            background.GetComponent<Image>().color = backgroundColor[0];
        }
        else
        {
            background.GetComponent<Image>().color = backgroundColor[1];
        }
    }

    public void wipeIncorrectAnswer(int i)
    {
        int index = SaveManager.instance.activeSave.roundScore.IndexOf(i);
        SaveManager.instance.activeSave.roundScore.RemoveAt(index);
        SaveManager.instance.activeSave.musName.RemoveAt(index);
        SaveManager.instance.activeSave.instrument.RemoveAt(index);
        SaveManager.instance.activeSave.band.RemoveAt(index);
        SaveManager.instance.activeSave.score = SaveManager.instance.activeSave.roundScore.Count;
        alreadyCounted = false;
    }
}
