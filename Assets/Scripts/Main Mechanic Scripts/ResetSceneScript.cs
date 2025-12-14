using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSceneScript : MonoBehaviour
{
    [SerializeField] private ResetTutorialTestScript resetTut;

    public void ResetWithTut()
    {
        resetTut.TutNotPlayedReset();
        resetTut.MonoNotPlayedReset();
        SceneManager.LoadScene(1);
    }

    public void ResetWithoutTut()
    {
        resetTut.TutPlayedReset();
        resetTut.MonoPlayedReset();
        SceneManager.LoadScene(1);
    }
}
