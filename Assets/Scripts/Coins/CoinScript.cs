using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public ScoreTracker scoreTrack;
    private AudioSource audioSrc;
    public AudioClip coinclip;
    public AudioClip keyclip;

    private void Start()
    {
        audioSrc = GameObject.Find("Audio Source").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if(other.gameObject.CompareTag("Coins"))
        {
            audioSrc.clip = coinclip;
            audioSrc.Play();
            scoreTrack.UpdateScore(1);
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("Key"))
        {
            audioSrc.clip = keyclip;
            audioSrc.Play();
        }
        
    }
}
