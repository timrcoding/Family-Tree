using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioMute : MonoBehaviour
{
    [HideInInspector]
    public RadioSingleton rs;
    [HideInInspector]
    public PlayCassette pc;
    public bool radioMuted;
    void Start()
    {
        rs = GameObject.FindObjectOfType<RadioSingleton>();
        pc = GameObject.FindObjectOfType<PlayCassette>();
    }

    public void switchRadio()
    {
        radioMuted = !radioMuted;
        if (radioMuted)
        {
            rs.audioSource.volume = 0;
        }
        else
        {
            rs.audioSource.volume = rs.radioVolume;
            pc.audioS.Stop();
        }
    }

    public void triggerRadioVol()
    {
        StartCoroutine(raiseRadioVolume());
    }

    public IEnumerator raiseRadioVolume()
    {
        rs.audioSource.volume += 0.005f;
        yield return new WaitForSeconds(Time.deltaTime * 2);
        if (rs.audioSource.volume < rs.radioVolume)
        {
            StartCoroutine(raiseRadioVolume());
        }
    }
}
