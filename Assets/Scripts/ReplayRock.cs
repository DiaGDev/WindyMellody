using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReplayRock : MonoBehaviour
{
    //waits before replaying a note
    public IEnumerator Replay(string[] sequence)
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        foreach (string item in sequence)
        {
            AudioClip clip = Resources.Load<AudioClip>(item);
            audioSource.clip = clip;
            audioSource.Play();
            yield return new WaitForSeconds(1.0f);
        }

    }

}
