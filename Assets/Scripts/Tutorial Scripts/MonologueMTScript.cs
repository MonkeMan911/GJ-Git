using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class MonologueMTScript : MonoBehaviour
{
    [SerializeField] private DisableSingularGOScript disableSingularGOScript;

    public TextMeshProUGUI textComp;
    public string[] lines;
    public float[] lineDurations; // duration for each line
    public AudioSource audioSource;
    public float pauseAfterLine = 2f;

    // Events for each line (same length as lines[])
    public UnityEvent[] lineEvents;

    private int index;

    void Start()
    {
        textComp.text = string.Empty;
        StartMonologue();
        disableSingularGOScript.DisableSingleObject();
    }

    void StartMonologue()
    {
        index = 0;
        audioSource.Play();
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        string currentLine = lines[index];
        float duration = lineDurations[index];
        float charDelay = duration / currentLine.Length;

        foreach (char c in currentLine.ToCharArray())
        {
            textComp.text += c;
            yield return new WaitForSeconds(charDelay);
        }

        // Trigger event for this line if assigned
        if (lineEvents != null && index < lineEvents.Length && lineEvents[index] != null)
        {
            lineEvents[index].Invoke();
        }

        // Pause audio for readability
        audioSource.Pause();
        yield return new WaitForSeconds(pauseAfterLine);

        NextLine();
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComp.text = string.Empty;
            audioSource.UnPause();
            StartCoroutine(TypeLine());
        }
        else
        {
            audioSource.Stop();
            gameObject.SetActive(false);
        }
    }
}

