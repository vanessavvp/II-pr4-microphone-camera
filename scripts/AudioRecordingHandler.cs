using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioRecordingHandler : MonoBehaviour {
    public AudioSource microphone;
    Button startButton;
    Button stopButton;
    Button playButton;
    string microphoneName;

    void Start() {
        microphoneName = Microphone.devices[1];
        microphone = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        startButton = GameObject.Find("StartAudio").GetComponent<Button>();
        startButton.onClick.AddListener(StartAction);
       
        stopButton = GameObject.Find("StopAudio").GetComponent<Button>();
        stopButton.onClick.AddListener(StopAction);
        
        playButton = GameObject.Find("PlayAudio").GetComponent<Button>();
        playButton.onClick.AddListener(PlayAction);
    }

    public void StartAction() {
        microphone.clip = Microphone.Start(microphoneName, true, 10, 44100);
    }

    public void StopAction() {
        if (Microphone.IsRecording(microphoneName)) {
            Microphone.End(microphoneName);
        }
    }

    public void PlayAction() {
        microphone.Play();
    }
}
