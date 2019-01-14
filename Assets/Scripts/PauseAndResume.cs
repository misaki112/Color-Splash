using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAndResume : MonoBehaviour {


    public bool paused;

    public GameObject pauseButton;

    public GameObject playButton;

    // Use this for initialization
    void Start () {
        paused = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onPaused()
    {
        paused = !paused;
        if (!paused)
        {
            Time.timeScale = 1f;
            playButton.SetActive(false);
            pauseButton.SetActive(true);
        }
        else
        {
            Time.timeScale = 0f;
            pauseButton.SetActive(false);
            playButton.SetActive(true);
        }
    }
}
