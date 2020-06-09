using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameResources : MonoBehaviour
{
    public TextAsset names;
    public TextAsset instruments;
    public List<Color> instColors;

    public List<string> musicianNames;
    public List<string> musicianInstruments;

    public List<GameObject> namesInBook;
    public List<GameObject> instrumentsInBook;
    // Start is called before the first frame update
    private void Awake()
    {
        musicianNames = new List<string>(names.text.Split('\n'));
        musicianInstruments = new List<string>(instruments.text.Split('\n'));

        GameObject[] musicians = GameObject.FindGameObjectsWithTag("Musician");
        for(int i = 0; i < musicians.Length; i++)
        {
            musicians[i].GetComponent<MemberID>().refId = i;
        }

        for (int i = 0; i < namesInBook.Count; i++)
        {
            namesInBook[i].GetComponent<TextMeshProUGUI>().text = musicianNames[i];
            namesInBook[i].name = musicianNames[i];
            namesInBook[i].tag = "Name";
            namesInBook[i].GetComponent<selectMemOrInst>().idNumber = i;
        }

        for (int i = 0; i < instrumentsInBook.Count; i++)
        {
            instrumentsInBook[i].GetComponent<TextMeshProUGUI>().text = musicianInstruments[i];
            instrumentsInBook[i].name = musicianInstruments[i];
            instrumentsInBook[i].tag = "Instrument";
            instrumentsInBook[i].GetComponent<selectMemOrInst>().idNumber = i;
        }


    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
