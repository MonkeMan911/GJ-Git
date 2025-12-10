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
        if (TutNotPlayed == true) 
        {
            PlayerPrefs.SetInt("TutorialPlayed", 0);
        }
        if (MonoNotPlayed == true) 
        {
            PlayerPrefs.SetInt("MonologuePlayed", 0);
        }
    }
}
