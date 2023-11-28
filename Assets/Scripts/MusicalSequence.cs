using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicalSequence : MonoBehaviour
{
    //stores the musical sequence needed to play
    public List<(string, float)> playedAudioClips = new List<(string, float)>();
    public string[][] audioSequences;

    private void Awake()
    {
        audioSequences = new string[][] {
        new string[] { "c5", "c5", "a4", "g4" },
        /*new string[] { "d6", "e6", "f6", "f6" },
        new string[] { "a4", "g4", "g6", "f6" },
        new string[] { "b6", "b6", "b6", "b4" }*/
        };
    }
}
