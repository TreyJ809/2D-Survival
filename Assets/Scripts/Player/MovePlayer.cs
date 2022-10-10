using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour {
    Rigidbody2D body;

    private static int primaryMouseButton= 0;
    private static int secondaryMouseButton = 1;
    private static int middleMouseButton = 2;

    public float aimDirection;
    public Vector2 playerPosition;
    public Vector2 cursorPosition;

    float horizontal;
    float vertical;
    bool leftClick;

    public float runSpeed;
    public Animator animator;
    public Sprite sidewaysFacingSprite;
    public Sprite downwardFacingSprite;
    public Sprite upwardFacingSprite;
    public SpriteRenderer mainBodyRenderer;
    public SpriteRenderer leftWeaponRenderer, rightWeaponRenderer;
    public MothershipScript mothership;

    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        leftClick = Input.GetMouseButton(primaryMouseButton);

        CalculateAimDirection();
    }

    private void FixedUpdate() {
        if (!mothership.IsGameOver()) {
            HandleMovements();
            HandleAttacking();
        } else {
            StopRunning();
            //StopAttacking(); //TODO might be needed later??? Implement or delete once more is understood
        }
    }

    private void HandleMovements() {
        if ((horizontal == 0 && vertical != 0) || (horizontal != 0 && vertical == 0)) {
            RunSingleDirection();
        } else if (horizontal != 0 && vertical != 0) {
            RunDiagonal();
        } else {
            StopRunning();
        }
    }

    private void StopRunning() {
        body.velocity = new Vector2(0, 0);
        animator.SetBool("IsRunning", false);
    }

    private void Run() {
        FlipSpriteRenderers();
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

    private void HandleAttacking() {
        if (leftClick) {
            animator.SetBool("IsAttacking", true);
        } else {
            animator.SetBool("IsAttacking", false);
        }
    }

    private void FlipSpriteRenderers() {
        if (horizontal < 0) {
            transform.localScale = new Vector3(1, 1, 1);
        } else if (horizontal > 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void CalculateAimDirection() {
        Vector3 rawPlayerPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 rawCursorPos = Input.mousePosition;

        float newX = rawCursorPos.x - rawPlayerPos.x;
        float newY = rawCursorPos.y - rawPlayerPos.y;
        float absX = Mathf.Abs(newX);
        float absY = Mathf.Abs(newY);

        if (newX <= 0 && absX > absY) {
            FaceLeft();
        } else if (newX >= 0 && absX > absY) {
            FaceRight();
        } else if (newY > 0 && absY > absX) {
            FaceUp();
        } else if (newY < 0 && absY > absX) {
            FaceDown();
        }
    }

    private void FaceLeft() {
        animator.SetBool("FacingLeft", true);
        animator.SetBool("FacingRight", false);
        animator.SetBool("FacingUp", false);
        animator.SetBool("FacingDown", false);

        mainBodyRenderer.sprite = sidewaysFacingSprite;
        transform.localScale = new Vector3(1, 1, 1);
    }

    private void FaceRight() {
        animator.SetBool("FacingLeft", false);
        animator.SetBool("FacingRight", true);
        animator.SetBool("FacingUp", false);
        animator.SetBool("FacingDown", false);

        mainBodyRenderer.sprite = sidewaysFacingSprite;
        transform.localScale = new Vector3(-1, 1, 1);
    }

    private void FaceUp() {
        animator.SetBool("FacingLeft", false);
        animator.SetBool("FacingRight", false);
        animator.SetBool("FacingUp", true);
        animator.SetBool("FacingDown", false);

        mainBodyRenderer.sprite = upwardFacingSprite;
    }

    private void FaceDown() {
        animator.SetBool("FacingLeft", false);
        animator.SetBool("FacingRight", false);
        animator.SetBool("FacingUp", false);
        animator.SetBool("FacingDown", true);

        mainBodyRenderer.sprite = downwardFacingSprite;
    }
}
