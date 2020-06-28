using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSingleton : MonoBehaviour
{
    private static RadioSingleton instance;
    public AudioSource audioSource;
    public float radioVolume = 0.5f;
    public float count;
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        if (!instance)
        {
            instance = this;
            audioSource.time = SaveManager.instance.activeSave.audioTimeline;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        audioSource.volume = 0;
        StartCoroutine(raiseRadioVolume());
    }

    private void Update()
    {
        SaveManager.instance.activeSave.audioTimeline = audioSource.time;
        
    }

    public IEnumerator raiseRadioVolume()
    {
        audioSource.volume += 0.005f;
        yield return new WaitForSeconds(Time.deltaTime * 2);
        if (audioSource.volume < radioVolume)
        {
            StartCoroutine(raiseRadioVolume());
        }
    }

}
