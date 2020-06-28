using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class ScoringSingleton : MonoBehaviour
{
    [HideInInspector]
    public PlayCassette pc;
    [HideInInspector]
    public RadioSingleton rs;

    private static ScoringSingleton instance;
    public bool[] correctlyIdentified;
    public bool[] musicianConfirmed;
    public string[] proposedNames;
    public int scoringCount;
    public int roundLength;
    public GameObject transition;

    public bool onStart;

    void Awake()
    {
        

        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        GameObject[] musicians = GameObject.FindGameObjectsWithTag("Musician");

        correctlyIdentified = new bool[musicians.Length];
        musicianConfirmed = new bool[musicians.Length];
        proposedNames = new string[musicians.Length];

        }

        
    

    private void Start()
    {
        pc = GameObject.FindObjectOfType<PlayCassette>();
        rs = GameObject.FindObjectOfType<RadioSingleton>();
        
        loadSaveData();
        StartCoroutine(setSaveData());
            
        
        
    }

    public void checkForCorrectAnswers()
    {
        GameObject[] answers = GameObject.FindGameObjectsWithTag("Musician");
        foreach(GameObject g in answers)
        {
            
            if (g.GetComponent<MemberID>().correctlyIdentified)
            {
                correctlyIdentified[g.GetComponent<MemberID>().refId] = true;
                if (!g.GetComponent<MemberID>().alreadyCounted)
                {
                    g.GetComponent<MemberID>().alreadyCounted = true;
                    saveRounds(scoringCount, g.GetComponent<MemberID>().refId, g.GetComponent<MemberID>().musicianName, g.GetComponent<MemberID>().instrumentName, g.GetComponent<MemberID>().band);
                    
                    scoringCount++;
                }
                
                checkForScoring(roundLength);
            }
            else
            {
                correctlyIdentified[g.GetComponent<MemberID>().refId] = false;
            }
        }
        
    }

    public void checkForScoring(int i)
    {
        if(SaveManager.instance.activeSave.score == i)
        {
            for(int j = 0; j < SaveManager.instance.activeSave.roundScore.Count; j++)
            {
                
                    musicianConfirmed[SaveManager.instance.activeSave.roundScore[j]] = true;
                    correctlyIdentified[SaveManager.instance.activeSave.roundScore[j]] = false;
                    setSaveData();
                
            }
            rs.audioSource.volume = 0;
            transition.SetActive(true);
            transition.GetComponent<Animator>().SetTrigger("Fade");
        }
    }

   public IEnumerator setSaveData()
    {
        yield return new WaitForSeconds(1);
        for(int i = 0; i < musicianConfirmed.Length; i++)
        {
            SaveManager.instance.activeSave.confirmedMusicians[i] = musicianConfirmed[i];
            SaveManager.instance.activeSave.correctlyIdentified[i] = correctlyIdentified[i];
            SaveManager.instance.activeSave.proposedNames[i] = proposedNames[i];
        }
        
        
        SaveManager.instance.Save();
        StartCoroutine(setSaveData());
    }

    public void saveRounds(int i,int reference,string name,string inst, string band)
    {
        SaveManager.instance.activeSave.roundScore.Add(reference);
        SaveManager.instance.activeSave.musName.Add(name);
        SaveManager.instance.activeSave.instrument.Add(inst);
        SaveManager.instance.activeSave.band.Add(band);
        SaveManager.instance.activeSave.score = SaveManager.instance.activeSave.roundScore.Count;


    }

    public void loadSaveData()
    {
        if (SaveManager.instance.hasLoaded)
        {
            for (int i = 0; i < musicianConfirmed.Length; i++)
            {
                musicianConfirmed[i] = SaveManager.instance.activeSave.confirmedMusicians[i];
                correctlyIdentified[i] = SaveManager.instance.activeSave.correctlyIdentified[i];
                proposedNames[i] = SaveManager.instance.activeSave.proposedNames[i];
            }
            
            scoringCount = SaveManager.instance.activeSave.score;
        }
    }

}
