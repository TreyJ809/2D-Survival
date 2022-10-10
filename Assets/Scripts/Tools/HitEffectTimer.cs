using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectTimer : MonoBehaviour
{
    private float initialLength;
    private float timeRemaining;

    private TimeSpan time;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        UpdateTimer();
        if (time.TotalMilliseconds <= 0) {
            Destroy(this.gameObject);
        }
    }

    private void UpdateTimer() {
        timeRemaining -= Time.deltaTime;
        time = TimeSpan.FromSeconds(timeRemaining);
    }

    public void SetInitialLength(float iLength) {
        initialLength = iLength;
        timeRemaining = initialLength;
        time = TimeSpan.FromSeconds(timeRemaining);
    }
}
