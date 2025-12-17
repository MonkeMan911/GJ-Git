using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManagerScript : MonoBehaviour
{
    [SerializeField] AudioSource MusicSource;
    [SerializeField] Slider MusicSlider;
    [SerializeField] Text MusicInt;
    [SerializeField] float vol;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vol = AudioListener.volume;
    }
    public void ChangeVolume()
    {
        MusicSource.volume = MusicSlider.value;
        float percent = MusicSlider.value * 100f;
        MusicInt.text = Mathf.RoundToInt(percent).ToString() + "%";
    }
}