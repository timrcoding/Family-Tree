using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameResources : MonoBehaviour
{
    [HideInInspector]
    public ScoringSingleton ss;

    public TextAsset names;
    public TextAsset instruments;
    public List<Color> instColors;

    public List<string> musicianNames;
    public List<string> musicianInstruments;

    public List<GameObject> namesInBook;
    public List<GameObject> instrumentsInBook;

    public List<TextAsset> bandInfo;
    public List<TextAsset> writtenResources;

    public GameObject popUp;
    public GameObject bandName;
    public GameObject dates;
    public GameObject TextBody;
    private void Awake()
    {

        Debug.Log(Application.persistentDataPath);
        ss = GameObject.FindObjectOfType<ScoringSingleton>();
        ss.scoringCount = 0;


        musicianNames = new List<string>(names.text.Split('\n'));
        musicianInstruments = new List<string>(instruments.text.Split('\n'));

        
        GameObject[] bands = GameObject.FindGameObjectsWithTag("Band");
        for (int i = 0; i < bands.Length; i++)
        {
            bands[i].GetComponent<BandID>().bandID = i;
        }
        GameObject[] wResources = GameObject.FindGameObjectsWithTag("writtenResource");
        for (int i = 0; i < wResources.Length; i++)
        {
            wResources[i].GetComponent<setWritResource>().idRef = i;
        }

        for (int i = 0; i < namesInBook.Count; i++)
        {
            namesInBook[i].GetComponent<TextMeshProUGUI>().text = musicianNames[i];
            namesInBook[i].name = musicianNames[i];
            //namesInBook[i].tag = "Name";
            namesInBook[i].GetComponent<selectMemOrInst>().idNumber = i;
        }

        for (int i = 0; i < instrumentsInBook.Count; i++)
        {
            instrumentsInBook[i].GetComponent<TextMeshProUGUI>().text = musicianInstruments[i];
            instrumentsInBook[i].name = musicianInstruments[i];
            //instrumentsInBook[i].tag = "Instrument";
            instrumentsInBook[i].GetComponent<selectMemOrInst>().idNumber = i;
        }

        ss.transition = GameObject.FindGameObjectWithTag("Transition");
        ss.transition.SetActive(false);
    }
    void Start()
    {
        
        GameObject[] musicians = GameObject.FindGameObjectsWithTag("Musician");
        for (int i = 0; i < musicians.Length; i++)
        {
            musicians[i].GetComponent<MemberID>().refId = i;
            LoadMusicianData();
        }
    }

    public void LoadMusicianData()
    {
        GameObject[] mus = GameObject.FindGameObjectsWithTag("Musician");
        for (int i = 0; i < mus.Length; i++)
        {
            mus[i].GetComponent<MemberID>().musicianNameText.GetComponent<TextMeshProUGUI>().text = SaveManager.instance.activeSave.proposedNames[i];
            mus[i].GetComponent<MemberID>().setColour();
            if (SaveManager.instance.activeSave.confirmedMusicians[i])
            {
                mus[i].GetComponent<MemberID>().confirmed = true;
            }
            
        }
    }


}
