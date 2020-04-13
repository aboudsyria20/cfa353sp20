using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
   // public AudioListener listener;
    public AudioMixer mixer;
    //public float vol;

    
    public void SetVolume(float volume)
    {
       mixer.SetFloat("Volume", volume);
        //AudioListener.volume = vol;
    }
}
