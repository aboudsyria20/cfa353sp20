using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public GameObject switchOn;
    public GameObject switchOff;
  public void OnChangeValue()
    {
        bool onoffSwitch = gameObject.GetComponent<Toggle>().isOn;
        if (onoffSwitch)
        {
            switchOn.SetActive(true);
            switchOff.SetActive(false);
            AudioListener.volume = 1f;
        }
        if(!onoffSwitch)
        {
            switchOn.SetActive(false);
            switchOff.SetActive(true);
            AudioListener.volume = 0f;
        }
    }
}
