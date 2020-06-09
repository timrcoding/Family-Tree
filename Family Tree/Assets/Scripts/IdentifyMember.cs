using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IdentifyMember : MonoBehaviour
{
    [HideInInspector]
    public GameResources gr;

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
                g.GetComponent<MemberID>().musicianInstrumentText.GetComponent<TextMeshProUGUI>().text = gr.musicianInstruments[instID];
                g.GetComponent<MemberID>().backgroundColor.color = gr.instColors[instID];

                g.GetComponent<MemberID>().proposedID = nameId;
                g.GetComponent<MemberID>().proposedInstrument = instID;
                
            }
            g.GetComponent<MemberID>().clickable = true;
        }
        notebook.SetActive(false);
    }
    
}
