using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayCassette : MonoBehaviour
{
    [HideInInspector]
    public RadioSingleton rs;

    public AudioSource audioS;
    public AudioSource cassAudio;
    
    public AudioClip[] song;
    public AudioClip[] cassetteSounds;
    public AudioClip mapSound;
    public AudioClip pencilScribble;
    public AudioClip bookSound;
    public AudioClip deckClosing;
    public bool playing;

    public bool musicPlayed;
    

    private void Awake()
    {

        rs = GameObject.FindObjectOfType<RadioSingleton>();

        GameObject[] songs = GameObject.FindGameObjectsWithTag("Song");
        for(int i = 0; i < songs.Length; i++)
        {
            songs[i].GetComponent<Song>().songId = i;
        }
        StartCoroutine(rs.raiseRadioVolume());
    }

    public void normalSpeed()
    {
        musicPlayed = true;
        rs.audioSource.volume = 0;
        randomCassetteSound();
        if (!playing)
        {
            audioS.Play();
        }
        audioS.pitch = 1;
        playing = true;
        
    }

    public void fastForward()
    {
        randomCassetteSound();
        
        audioS.pitch = 4;
        
    }

    public void rewind()
    {
        randomCassetteSound();
        
        audioS.pitch = -4;
        
    }

    public void stopAudio()
    {
        StartCoroutine(raiseRadioVolume());
        randomCassetteSound();
        audioS.pitch = 1f;
        audioS.Stop();
        playing = false;

    }

    public void fadeMusic()
    {
            audioS.volume = Mathf.Lerp(audioS.volume,0,0.1f);
            if (audioS.volume > 0.05f)
            {
                fadeMusic();
            }
        
    }

    public void randomCassetteSound()
    {
        cassAudio.PlayOneShot(cassetteSounds[Random.Range(0, cassetteSounds.Length)],0.6f);
    }

    public void cassDeckClosing()
    {
        cassAudio.PlayOneShot(deckClosing);
    }

    public IEnumerator raiseRadioVolume()
    {
        rs.audioSource.volume += 0.005f;
        yield return new WaitForSeconds(Time.deltaTime*2);
        if(rs.audioSource.volume < rs.radioVolume)
        {
           StartCoroutine(raiseRadioVolume());
        }
    }

}
