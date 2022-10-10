using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{

    public PlayerHealthDisplay playerHealthDisplay;
    public MothershipScript mothership;
    public SpriteRenderer spriteRenderer;
    public float invulnerabilityTimer;

    private bool isInvulnerable;

    private HitEffectTimer hitEffectTimer;

    // Start is called before the first frame update
    void Start()
    {
        isInvulnerable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsInvulnerable() && hitEffectTimer == null) {
            ExitInvulnerableState();
        }
    }

    public override void TakeDamage(int d) {
        base.TakeDamage(d);
        UpdatePlayerHealthDisplay();
        EnterInvulnerableState();
        hitEffectTimer = CreateHitEffectTimer();
        hitEffectTimer.SetInitialLength(invulnerabilityTimer);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (!IsInvulnerable() && collision.gameObject.tag == "Enemy") {
            TakeDamage();
        }
    }

    private void UpdatePlayerHealthDisplay() {
        playerHealthDisplay.UpdatePlayerHealthDisplay(currentHealth, maxHealth);
    }

    public override void Die() {
        mothership.EndGame();
    }

    public bool IsInvulnerable() {
        return isInvulnerable;
    }

    private void SetInvulnerable(bool invuln) {
        isInvulnerable = invuln;
    }

    private void EnterInvulnerableState() {
        SetInvulnerable(true);
        TransparentTint();
    }

    private void ExitInvulnerableState() {
        SetInvulnerable(false);
        NormalTint();
    }

    private void StartInvulnerabilityTimer() {
        
    }

    private void TransparentTint() {
        spriteRenderer.color = new Color(0.5f, 0.5f, 0.5f, 0.75f);
    }

    private void NormalTint() {
        spriteRenderer.color = Color.white;
    }

    private HitEffectTimer CreateHitEffectTimer() {
        GameObject gameObject = new GameObject("HitEffectTimer");
        return gameObject.AddComponent<HitEffectTimer>();
    }
}
