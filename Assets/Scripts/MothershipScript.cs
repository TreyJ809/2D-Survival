using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MothershipScript : MonoBehaviour
{
    System.Random rnd;

    private bool gameOver;

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
    }
    // Update is called once per frame
    void Update()
    {
        
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

    public float GetDelayInterval() {
        return spawnDelay;
    }

    public List<GameObject> GetSausagesTypes() {
        return sausageTypes;
    }

}
