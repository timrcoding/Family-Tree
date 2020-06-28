using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public bool[] musicianCorrect;
    public int[] musicianInRound;
    public string[] proposedNames;

    public GameData(ScoringSingleton ss)
    {
        musicianCorrect = new bool[30];
        musicianInRound = new int[5];
        for(int i = 0; i < ss.correctlyIdentified.Length; i++)
        {
            musicianCorrect[i] = ss.correctlyIdentified[i];
        }
        for(int j = 0; j < 5; j++)
        {
            //musicianInRound[j] = ss.roundScores[j];
        }
        for (int k = 0; k < 5; k++)
        {
            proposedNames[k] = ss.proposedNames[k];
        }
    }
}
