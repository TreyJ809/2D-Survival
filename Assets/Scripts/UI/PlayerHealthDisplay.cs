using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthDisplay : MonoBehaviour
{

    public Sprite fullHeartSprite;
    public Sprite emptyHeartSprite;

    public HeartDisplay heartDisplay;

    private int maxHearts;
    private int currentHearts;

    private List<HeartDisplay> heartsDisplayList;

    private void Awake() {
        heartsDisplayList = new List<HeartDisplay>();
        UpdatePlayerHealthDisplay(3, 3);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePlayerHealthDisplay(int currentHealth, int maxHealth) {
        //TODO: Sometimes the display doesn't update when damaged even though damage is registered (as shown by game ending on 3 hits)

        UpdateMaxHearts(maxHealth);
        UpdateCurrentHearts(currentHealth);
    }

    private void UpdateMaxHearts(int maxHealth) {
        maxHearts = maxHealth;

        Vector3 spaceBetweenHearts = new Vector3(1f, 0f, 0f);

        int heartsDifference = heartsDisplayList.Count - maxHearts;

        if (heartsDifference < 0) { //add extra hearts because maxHealth has increased

            Vector3 position;
            if (heartsDisplayList.Count > 0) {
                position = heartsDisplayList[heartsDisplayList.Count - 1].GetComponent<Transform>().position;
            } else {
                position = GetComponent<Transform>().position;
            }

            for (int i = 0; i < -heartsDifference; i++) {
                HeartDisplay hd = Instantiate(heartDisplay, position, Quaternion.identity);
                SpriteRenderer sr = hd.GetComponent<SpriteRenderer>();
                sr.sprite = emptyHeartSprite;
                heartsDisplayList.Add(hd);

                position = position + spaceBetweenHearts;
            }
        } else if (heartsDifference > 0) { //remove extra hearts because maxHealth has decreased
            for (int i = 0; i < heartsDifference; i++) {
                heartsDisplayList.RemoveAt(heartsDisplayList.Count);
            }
        } else { //if the max hearts is unchanged
            //do nothing
        }
    }

    private void UpdateCurrentHearts(int currentHealth) {
        currentHearts = currentHealth;
        int countDown = currentHearts;

        foreach (HeartDisplay hd in heartsDisplayList) {
            if (countDown > 0) {
                hd.GetComponent<SpriteRenderer>().sprite = fullHeartSprite;
                countDown--;
            } else {
                hd.GetComponent<SpriteRenderer>().sprite = emptyHeartSprite;
            }
        }
    }
}
