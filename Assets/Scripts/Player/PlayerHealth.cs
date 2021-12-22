using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{

    public PlayerHealthDisplay playerHealthDisplay;
    public MothershipScript mothership;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage(int d) {
        base.TakeDamage(d);
        UpdatePlayerHealthDisplay();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            TakeDamage();
            //TODO: Disable collider briefly to prevent enemies from shoving player
        }
    }

    private void UpdatePlayerHealthDisplay() {
        playerHealthDisplay.UpdatePlayerHealthDisplay(currentHealth, maxHealth);
    }

    public override void Die() {
        mothership.EndGame();
    }
}
