using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : EnemyController
{
    [SerializeField] private float jumpHeight = 8f;
    [SerializeField] private float jumpImpulse = -4f;

    protected override void Start() {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartCoroutine(StartMove());
    }

    protected override void FixedUpdate() {}

    protected override void Move() {
        anim.SetBool("Jumping", true);

        if (jumpImpulse < 0) {
            rig.AddForce(new Vector2(jumpImpulse, jumpHeight), ForceMode2D.Impulse);
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f); 
        }
        else if (jumpImpulse > 0) {
            rig.AddForce(new Vector2(jumpImpulse, jumpHeight), ForceMode2D.Impulse);
            transform.rotation = new Quaternion(0f, 180f, 0f, 0f); 
        }
        jumpImpulse *= -1;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) {
            anim.SetBool("Jumping", false);
        }
    }


    IEnumerator StartMove() {
        while (true) {
            Move();
            yield return new WaitForSeconds(3f);
        }
    }
}
