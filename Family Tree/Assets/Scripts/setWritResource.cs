using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class setWritResource : MonoBehaviour
{
    [HideInInspector]
    public GameResources gr;
    [HideInInspector]
    public PlayCassette pc;

    public int idRef;
    public List<string> mainText;
    public bool doubleSpacing;

    private void Awake()
    {
        gr = GameObject.FindObjectOfType<GameResources>();
        pc = GameObject.FindObjectOfType<PlayCassette>();
    }
    void Start()
    {
        mainText = new List<string>(gr.writtenResources[idRef].text.Split('\n'));
        transform.GetComponentInChildren<TextMeshProUGUI>().text = mainText[0];

    }

    public void setText()
    {
        pc.cassAudio.PlayOneShot(pc.mapSound);
        GameObject mText = GameObject.FindGameObjectWithTag("MainText");
        mText.GetComponent<TextMeshProUGUI>().text = "";
        for (int i = 1; i < mainText.Count; i++)
        {
            if (doubleSpacing && mainText[i] != null)
            {
                mText.GetComponent<TextMeshProUGUI>().text += mainText[i] + '\n' + '\n';
            }
            else if(mainText[i] != null)
            {
                mText.GetComponent<TextMeshProUGUI>().text += mainText[i] + '\n';
            }
           
        }
        GameObject sBar = GameObject.FindGameObjectWithTag("Scrollbar");
        sBar.GetComponent<Scrollbar>().value = 0;
        
    }
}
