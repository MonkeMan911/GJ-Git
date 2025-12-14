using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTutorialTestScript : MonoBehaviour
{
    public bool TutNotPlayed;
    public bool MonoNotPlayed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (TutNotPlayed == true) 
        //{
        //    PlayerPrefs.SetInt("TutorialPlayed", 0);
        //}
        //if (MonoNotPlayed == true) 
        //{
        //    PlayerPrefs.SetInt("MonologuePlayed", 0);
        //}
    }

    public void TutNotPlayedReset()
    {
        PlayerPrefs.SetInt("TutorialPlayed", 0);
        PlayerPrefs.Save();
    }

    public void TutPlayedReset()
    {
        PlayerPrefs.SetInt("TutorialPlayed", 1);
        PlayerPrefs.Save();
    }

    public void MonoNotPlayedReset()
    {
        PlayerPrefs.SetInt("MonologuePlayed", 0);
        PlayerPrefs.Save();
    }

    public void MonoPlayedReset()
    {
        PlayerPrefs.SetInt("MonologuePlayed", 1);
        PlayerPrefs.Save();
    }


}
