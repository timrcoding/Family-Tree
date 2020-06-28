using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Song : MonoBehaviour
{
    [HideInInspector]
    public PlayCassette pc;
    [HideInInspector]
    public GameResources gr;
    [HideInInspector]
    public RadioSingleton rs;

    public List<string> bandInfo;
    public int songId;
    public GameObject textBody;

    private void Awake()
    {
        pc = GameObject.FindObjectOfType<PlayCassette>();
        gr = GameObject.FindObjectOfType<GameResources>();
        rs = GameObject.FindObjectOfType<RadioSingleton>();
    }

    

    public void playSong()
    {
        readTextAsset();
        pc.audioS.Stop();
        pc.cassDeckClosing();
        pc.audioS.clip = pc.song[songId];
        pc.audioS.Play();
        rs.audioSource.volume = 0;
        pc.playing = true;
    }

    void readTextAsset()
    {
        if (gr.bandInfo[songId] != null)
        {
            bandInfo = new List<string>(gr.bandInfo[songId].text.Split('\n'));
        }
        textBody.GetComponent<TextMeshProUGUI>().text = bandInfo[2];
    }
}
