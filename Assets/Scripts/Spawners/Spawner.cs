using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    protected Vector2 directionForSpawns;
    protected bool spawnsFlipX;
    
    protected float delayInterval;
    protected float timeElapsed;

    protected float upperBound;
    protected float lowerBound;
    protected float rightBound;
    protected float leftBound;

    protected System.Random rnd;

    protected Transform t;

    protected List<GameObject> sausageTypes;

    public MothershipScript mothership;

    // Start is called before the first frame update
    void Start() {
        SetBounds();

        leftBound = -rightBound;

        rnd = mothership.GetRandom();

        t = GetComponent<Transform>();

        delayInterval = mothership.GetDelayInterval();
        timeElapsed = 0f;

        sausageTypes = mothership.GetSausagesTypes();

        SetDirectionForSpawns();
        SetSpawnsFlipX();
    }

    // Update is called once per frame
    void Update() {
        if (mothership.IsGameOver() == false) {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= delayInterval && !mothership.IsGameOver()) {
                Teleport();
                Spawn();
                timeElapsed = 0f;
            }
        }
    }

    protected void Spawn() {
        GameObject sausageObject = Instantiate(sausageTypes[0], t.position, Quaternion.identity);
        SausageScript sausage = sausageObject.GetComponent<SausageScript>();
        sausage.SetDirection(directionForSpawns);
        sausage.Flip(spawnsFlipX);
    }

    protected abstract void Teleport();

    protected abstract void SetBounds();

    protected abstract void SetDirectionForSpawns();

    protected abstract void SetSpawnsFlipX();

}
