using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IdentifyMember : MonoBehaviour
{
    [HideInInspector]
    public GameResources gr;
    [HideInInspector]
    public ResizeTree rt;
    [HideInInspector]
    public PlayCassette pc;
    [HideInInspector]
    public ScoringSingleton ss;

    public GameObject notebook;
    public TextMeshProUGUI nameField;
    public TextMeshProUGUI instrumentField;
    public Image backgroundToID;
    public int nameId;
    public int instID;
    public int musicianRef;
    void Start()
    {
        gr = GameObject.FindObjectOfType<GameResources>();  
        rt = GameObject.FindObjectOfType<ResizeTree>();  
        pc = GameObject.FindObjectOfType<PlayCassette>();  
        ss = GameObject.FindObjectOfType<ScoringSingleton>();  
    }


    public void musicianIdentified(int index)
    {
        nameId = index;
        nameField.text = gr.musicianNames[nameId];
        

    }
    public void instrumentIdentified(int index)
    {
        
        instID = index;
        instrumentField.text = gr.musicianInstruments[instID];
        backgroundToID.color = gr.instColors[instID];
    }

    public void setToMusician()
    {
        
        GameObject[] musicians = GameObject.FindGameObjectsWithTag("Musician");
        foreach(GameObject g in musicians)
        {
            if(g.GetComponent<MemberID>().refId == musicianRef)
            {
                g.GetComponent<MemberID>().musicianNameText.GetComponent<TextMeshProUGUI>().text = gr.musicianNames[nameId];
                g.GetComponent<MemberID>().proposedID = nameId;
                g.GetComponent<MemberID>().proposedIDName = gr.musicianNames[nameId];
                g.GetComponent<MemberID>().proposedInstrument = instID;
                g.GetComponent<MemberID>().proposedInstrumentName = gr.musicianInstruments[instID];
                g.GetComponent<MemberID>().checkForId();
                ss.proposedNames[g.GetComponent<MemberID>().refId] = gr.musicianNames[nameId];



            }
            g.GetComponent<MemberID>().GetComponent<BoxCollider2D>().enabled = true;
        }
        GameObject[] bands = GameObject.FindGameObjectsWithTag("Band");
        
            foreach(GameObject band in bands)
            {
            band.GetComponent<BandID>().GetComponent<BoxCollider2D>().enabled = true;
            }
        
        notebook.SetActive(false);
        rt.resizeable = true;
        pc.cassAudio.PlayOneShot(pc.pencilScribble,0.6f);

    }

    public void cancelNotebook()
    {

        GameObject[] musicians = GameObject.FindGameObjectsWithTag("Musician");
        foreach (GameObject g in musicians)
        {
            
            g.GetComponent<MemberID>().GetComponent<BoxCollider2D>().enabled = true;
        }
        GameObject[] bands = GameObject.FindGameObjectsWithTag("Band");

        foreach (GameObject band in bands)
        {
            band.GetComponent<BandID>().GetComponent<BoxCollider2D>().enabled = true;
        }
        notebook.SetActive(false);
        rt.resizeable = true;
        pc.cassAudio.PlayOneShot(pc.bookSound);
    }
    
}
