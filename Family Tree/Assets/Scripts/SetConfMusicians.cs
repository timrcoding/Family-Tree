using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class SetConfMusicians : MonoBehaviour
{
    [HideInInspector]
    public ScoringSingleton ss;

    public GameObject[] musicians;
    public GameObject musCountText;
    public int musCount;
    public GameObject endText;

    private void Awake()
    {
        ss = GameObject.FindObjectOfType<ScoringSingleton>();
    }
    void Start()
    {
        

        for(int  i = 0; i < 5; i++)
        {
            musicians[i].GetComponent<MemberID>().musicianNameText.GetComponent<TextMeshProUGUI>().text = SaveManager.instance.activeSave.musName[i];
            musicians[i].GetComponent<MemberID>().musicianInstrumentText.GetComponent<TextMeshProUGUI>().text = SaveManager.instance.activeSave.instrument[i];
            musicians[i].GetComponent<MemberID>().musicianBandText.GetComponent<TextMeshProUGUI>().text = SaveManager.instance.activeSave.band[i];
        }
        StartCoroutine(fadeInMusicians(0));
        for (int j = 0; j < ss.musicianConfirmed.Length; j++)
        {
            if (ss.musicianConfirmed[j])
            {
                musCount++;
            }
        }
        setMusCount();
    }
    public IEnumerator fadeInMusicians(int count)
    {
        
        yield return new WaitForSeconds(2);
        musicians[count].GetComponent<Animator>().SetTrigger("Fade");
        count++;
        if (count < 5)
        {
            StartCoroutine(fadeInMusicians(count));
        }
        else
        {
            endText.GetComponent<Animator>().SetTrigger("Fade");
        }
    }

    public void setMusCount()
    {
        int musConfirmed = SaveManager.instance.activeSave.confirmedMusicians.Where(c => c).Count();
        musCountText.GetComponent<TextMeshProUGUI>().text = (30 - musConfirmed).ToString() + " Musicians Remain";
    }
    
}
