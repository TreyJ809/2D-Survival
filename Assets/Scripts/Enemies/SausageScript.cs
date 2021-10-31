using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SausageScript : MonoBehaviour
{
    public int speed;

    public Vector2 direction;

    public SpriteRenderer spriteRenderer;
    public Animator animator;

    private MothershipScript mothership;

    private Transform t;

    // Start is called before the first frame update
    void Start() {
        mothership = GameObject.FindWithTag("Mothership").GetComponent<MothershipScript>();

        t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDirection(Vector2 d) {
        direction = d;
    }

    public void Flip(bool flip) {
        spriteRenderer.flipX = flip;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Boundary") {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate() {
        if (!mothership.IsGameOver()) {
            Move();
        }
    }

    private void Move() {
        float x = t.position.x;
        float y = t.position.y;
        float z = t.position.z;
        t.position = new Vector3( x + (direction.x * .1f * speed), y + (direction.y * .1f * speed), z );
    }

}
