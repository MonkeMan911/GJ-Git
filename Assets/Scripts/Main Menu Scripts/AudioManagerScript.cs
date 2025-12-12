using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManagerScript : MonoBehaviour
{
    [SerializeField] Slider AudioSlider;
    [SerializeField] Text audioInt;
    [SerializeField] float vol;
    void Start()
    {
        if (!PlayerPrefs.HasKey("AudioVolume")) 
        {
            PlayerPrefs.SetFloat("AudioVolume", 100);
            Load();
        }
        else 
        {
            Load();
        }
    }

    // Update is called once per frame
    void Update()
    {
        vol = AudioListener.volume;
    }
    public void ChangeVolume() 
    {
        AudioListener.volume = AudioSlider.value;
        audioInt.text = AudioSlider.value.ToString();
    }
    public void Save() 
    {
        PlayerPrefs.SetFloat("AudioVolume", AudioSlider.value);
    }
    public void Load() 
    {
        AudioSlider.value = PlayerPrefs.GetFloat("AudioVolume");
    }
}
