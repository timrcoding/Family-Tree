using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPrefs : MonoBehaviour
{
    [HideInInspector]
    public ScoringSingleton ss;
    private void Awake()
    {
        ss = GameObject.FindObjectOfType<ScoringSingleton>();
    }

    public void clearRoundScores()
    {
        SaveManager.instance.activeSave.roundScore.Clear();
        SaveManager.instance.activeSave.musName.Clear();
        SaveManager.instance.activeSave.instrument.Clear();
        SaveManager.instance.activeSave.band.Clear();
        SaveManager.instance.activeSave.score = 0;
        SaveManager.instance.Save();


    }
}
