using UnityEngine;

public class AudioSourceSwapper : MonoBehaviour
{
    //Used to swap between notes 
    public AudioSource[] audioSources; 
    public int startingIndex = 0; 

    private int currentAudioSourceIndex; 

    void Start()
    {

        currentAudioSourceIndex = startingIndex;


        for (int i = 0; i < audioSources.Length; i++)
        {
            Debug.Log(i);
            if (i == currentAudioSourceIndex)
            {
                audioSources[i].enabled = true;
            }
            else
            {
                audioSources[i].enabled = false;
            }
        }
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

            for (int i = 0; i < audioSources.Length; i++)
            {
                if (i == currentAudioSourceIndex)
                {
                    audioSources[i].enabled = true;
                }
                else
                {
                    audioSources[i].enabled = false;
                }
            }
        }
    }
}