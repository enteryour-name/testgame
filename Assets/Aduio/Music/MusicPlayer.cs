using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource introsource, loopsource;
    // Start is called before the first frame update
    void Start()
    {
        introsource.Play();
        loopsource.PlayScheduled(AudioSettings.dspTime+introsource.clip.length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
