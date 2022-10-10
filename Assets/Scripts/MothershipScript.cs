using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MothershipScript : MonoBehaviour
{
    System.Random rnd;

    private bool gameOver;
    private bool paused;

    public float spawnDelay;

    public List<GameObject> sausageTypes;

    public PlayerHealthDisplay playerHealthDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake() {
        rnd = new System.Random();
        gameOver = true;
        paused = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            TogglePause();
        }
    }

    public System.Random GetRandom() {
        return rnd;
    }

    public bool IsGameOver() {
        return gameOver;
    }

    private void SetGameOver(bool over) {
        gameOver = over;
    }

    public void EndGame() {
        SetGameOver(true);
        SceneManager.LoadScene("StartMenu");
    }

    public void StartGame() {
        SetGameOver(false);
    }

    private void PauseGame() {
        Time.timeScale = 0;
        AudioListener.pause = true;
        paused = true;
    }
    private void UnpauseGame() {
        Time.timeScale = 1;
        AudioListener.pause = false;
        paused = false;
    }

    public void TogglePause() {
        if (paused) {
            UnpauseGame();
        } else {
            PauseGame();
        }
    }

    public bool IsPaused() {
        return paused;
    }

    public float GetDelayInterval() {
        return spawnDelay;
    }

    public List<GameObject> GetSausagesTypes() {
        return sausageTypes;
    }

    

}
