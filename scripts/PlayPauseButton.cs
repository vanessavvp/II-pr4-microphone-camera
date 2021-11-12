using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPauseButton : MonoBehaviour {
    RawImage display;
    Button stopButton;
    Button playButton;
    Button pauseButton;
    WebCamTexture webCamTexture;

    public void Start() {
        display = GameObject.Find("RawImage").GetComponent<RawImage>();
        playButton = GameObject.Find("PlayVideo").GetComponent<Button>();
        playButton.onClick.AddListener(PlayAction);
       
        pauseButton = GameObject.Find("PauseVideo").GetComponent<Button>();
        pauseButton.onClick.AddListener(PauseAction);

        stopButton = GameObject.Find("StopVideo").GetComponent<Button>();
        stopButton.onClick.AddListener(StopAction);
    }

    public void PlayAction() {
        if (webCamTexture == null) {
            webCamTexture = new WebCamTexture(WebCamTexture.devices[1].name);
        }
        display.texture = webCamTexture;
        webCamTexture.Play();
    }
    
    public void PauseAction() {
        if (webCamTexture.isPlaying) {
            webCamTexture.Pause();
        }
    }
 
    public void StopAction() {
        if (webCamTexture != null) {
            display.texture = null;
            webCamTexture.Stop();
            webCamTexture = null;
        }
    }
}
