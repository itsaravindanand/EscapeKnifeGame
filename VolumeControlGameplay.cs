using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControlGameplay : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("GamePlayVol", volume);
    }
}
