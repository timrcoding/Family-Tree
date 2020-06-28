using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveGameData : MonoBehaviour
{
    [HideInInspector]
    public ScoringSingleton ss;

    private void Awake()
    {
        ss = GameObject.FindObjectOfType<ScoringSingleton>();
    }

    private void Start()
    {
        //LoadMusicianData();
        StartCoroutine(SaveData());
    }

    public IEnumerator SaveData()
    {
        yield return new WaitForSeconds(1);
        for(int i = 0; i < ss.correctlyIdentified.Length; i++)
        {
            PlayerPrefs.SetString("ProposedName" + i, ss.proposedNames[i]);
            if (ss.correctlyIdentified[i])
            {
                PlayerPrefs.SetInt("CorrectlyIdentified" + i, 1);
                PlayerPrefs.SetInt("MusicianConfirmed" + i, 1);
            }
            else
            {
                PlayerPrefs.SetInt("CorrectlyIdentified" + i, 0);
                PlayerPrefs.SetInt("MusicianConfirmed" + i, 0);
            }

        }
        StartCoroutine(SaveData());
    }

   
}
