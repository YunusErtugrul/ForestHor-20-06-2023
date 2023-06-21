using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SounTrigger : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;
    public bool alReady = false;
    

    private void OnTriggerEnter(Collider other)
    {
        if (!alReady) { 
        audioSource.PlayOneShot(clip, volume);
            alReady = true;
        }
    }
}
