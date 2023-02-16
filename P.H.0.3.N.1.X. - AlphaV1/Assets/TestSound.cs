using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
   [SerializeField] private  SoundData soundData;

    private void Start()
    {
        soundData.source = gameObject.AddComponent<AudioSource>();
        soundData.SetupAudioSource();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            soundData.PlayAudio();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            soundData.StopAudio();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            soundData.SetAudioLoop(false);
        }
    }
}
