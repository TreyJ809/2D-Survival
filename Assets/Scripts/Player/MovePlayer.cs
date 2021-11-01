using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour {
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public MothershipScript mothership;

    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {
        if (!mothership.IsGameOver()) {
            if ((horizontal == 0 && vertical != 0) || (horizontal != 0 && vertical == 0)) {
                RunSingleDirection();
            } else if (horizontal != 0 && vertical != 0) {
                RunDiagonal();
            } else {
                Stop();
            }
        } else {
            Stop();
        }
    }

    private void Stop() {
        body.velocity = new Vector2(0, 0);
        animator.SetBool("IsRunning", false);
    }

    private void Run() {
        if (horizontal < 0) {
            spriteRenderer.flipX = true;
        } else if (horizontal > 0) {
            spriteRenderer.flipX = false;
        }

        animator.SetBool("IsRunning", true);
    }

    private void RunSingleDirection() {
        Run();
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private void RunDiagonal() {
        Run();
        float speedScale = .7f;
        body.velocity = new Vector2((horizontal * runSpeed) * speedScale, (vertical * runSpeed) * speedScale);
    }

}
