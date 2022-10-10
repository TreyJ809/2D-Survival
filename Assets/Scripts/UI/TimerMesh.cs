using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Timer shown at top of screen indicating time played
public class TimerMesh : MonoBehaviour {

    private float timeElapsed;

    public MothershipScript mothership;

    public TMP_Text timerDisplay;

    // Start is called before the first frame update
    void Start() {
        timeElapsed = 0f;
    }

    // Update is called once per frame
    void Update() {
        if (!mothership.IsGameOver()) {
            UpdateTimer();
        }
    }

    private void UpdateTimer() {
        timeElapsed += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(timeElapsed);
        timerDisplay.text = time.ToString("mm':'ss");
    }
}
