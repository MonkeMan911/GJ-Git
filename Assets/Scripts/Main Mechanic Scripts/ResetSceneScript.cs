using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSceneScript : MonoBehaviour
{
    public ResetTutorialTestScript resetTut;

    public void ResetWithTut()
    {
        resetTut.TutNotPlayed = true;
        resetTut.MonoNotPlayed = true;
        Scene activeS = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeS.name);
    }
    public void ResetWithoutTut()
    {
        resetTut.TutNotPlayed= false;
        resetTut.MonoNotPlayed= false;
        Scene activeS = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeS.name);
    }
}
