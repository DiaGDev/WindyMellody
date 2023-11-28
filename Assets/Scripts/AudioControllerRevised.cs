using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Xml.Linq;

public class AudioControllerRevised : MonoBehaviour
{
    MusicalSequence ms;
    ReplayRock rpr;
    public GameObject lightToActivate;
    public GameObject slimeToActivate;
    public TextMeshProUGUI sequenceDisplay;
    public AudioSource[] audioSources;
    private int currentAudioSourceIndex = 0;
    private static int currentNoteIndex = 0;
    private static int currentSequenceIndex = 0;
    private static string message;
    public bool played = false;
    private static bool done = false;

    private void Awake()
    {
        GameObject MSC = GameObject.Find("MusicalSequenceController");
        ms = MSC.GetComponent<MusicalSequence>();
        rpr = MSC.GetComponent<ReplayRock>();
        message = "c5, c5, a4, g4";
    }

    void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
        {

            currentAudioSourceIndex += (int)Mathf.Sign(Input.mouseScrollDelta.y);

            if (currentAudioSourceIndex >= audioSources.Length)
            {
                currentAudioSourceIndex = 0;
            }
            else if (currentAudioSourceIndex < 0)
            {
                currentAudioSourceIndex = audioSources.Length - 1;
            }
        }

        sequenceDisplay.text = message;
        if(done)
        {
            if (!lightToActivate.activeSelf && !slimeToActivate.activeSelf)
            {
                lightToActivate.SetActive(true);
                slimeToActivate.SetActive(true);
            }

        }
    }

    public void ifClicked()
    {

        if (!played)
        {
            if (done == false)
            {
                if (audioSources[currentAudioSourceIndex].clip.name == ms.audioSequences[currentSequenceIndex][currentNoteIndex])
                {
                    message = string.Join(", ", ms.audioSequences[currentSequenceIndex]);
                    StartCoroutine(FlashColor(Color.green, 0.5f));
                    if (currentNoteIndex >= ms.audioSequences[currentSequenceIndex].Length - 1)
                    {
                        audioSources[currentAudioSourceIndex].Play();
                        currentNoteIndex = 0;
                        StartCoroutine(rpr.Replay(ms.audioSequences[currentSequenceIndex]));
                        currentSequenceIndex++;
                        if (currentSequenceIndex >= ms.audioSequences.Length)
                        {
                            currentSequenceIndex = 0;
                            StartCoroutine(FlashColor(Color.yellow, 0.5f));
                            message = "Slime Summoned!";
                            done = true;
                        }
                    }
                    currentNoteIndex++;
                }
                else
                {
                    message = string.Join(", ", ms.audioSequences[currentSequenceIndex]);
                    StartCoroutine(FlashColor(Color.red, 0.5f));
                    currentNoteIndex = 0;

                }

            }

            audioSources[currentAudioSourceIndex].Play();
            played = true;
        }

    }


    private IEnumerator FlashColor(Color color, float duration)
    {
        sequenceDisplay.color = color;
        yield return new WaitForSeconds(duration);
        sequenceDisplay.color = Color.white;
    }
}
