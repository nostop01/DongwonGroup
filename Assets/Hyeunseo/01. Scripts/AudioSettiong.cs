using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettiong : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider masterAudioSlider;
    public Slider bgmAudioSlider;
    public Slider sfxAudioSlider;

    public void AudioControl()
    {
        float masterSound = masterAudioSlider.value;
        float bgmSound = bgmAudioSlider.value;
        float sfxSound = sfxAudioSlider.value;

        if (masterSound == -40f)
        {
            masterMixer.SetFloat("Master", -80); //40이하로 내려가면 음소거 설정
        }
        else
        {
            masterMixer.SetFloat("Master", masterSound); //아닐 경우 사운드 조절
        }

        if (bgmSound == -40f)
        {
            masterMixer.SetFloat("BGM", -80);
        }
        else
        {
            masterMixer.SetFloat("BGM", bgmSound);
        }

        if (sfxSound == -40f)
        {
            masterMixer.SetFloat("SFX", -80);
        }
        else
        {
            masterMixer.SetFloat("SFX", sfxSound);
        }
    }

    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
}
