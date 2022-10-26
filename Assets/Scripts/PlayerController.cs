using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 4f;
    private float hInput;
    private bool isJumping = false;
    private Animator playerAnim;
    private Rigidbody2D playerRig;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRig = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!GameManager.Instance.gameOver) {
            Move();
        }
    }

    private void Update() {
        if (!GameManager.Instance.gameOver) {
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping) {
                Jump(1f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (!GameManager.Instance.gameOver) {
            if (other.gameObject.CompareTag("Ground")) {
                playerAnim.SetBool("Jumping", false);
                isJumping = false;
            }   
        }
         
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!GameManager.Instance.gameOver) {
            if (other.gameObject.CompareTag("Enemy")) {
                Die();
            }  

            if (other.gameObject.CompareTag("EnemyHead")) {
                Jump(1.5f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Background")) {
            Die();
        }
    }

    private void Move() {
        hInput = Input.GetAxis("Horizontal");

        if (hInput > 0) {
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f); 
        }
        else if (hInput < 0) {
            transform.rotation = new Quaternion(0f, 180f, 0f, 0f); 
        }

        if (hInput != 0) {
            playerAnim.SetBool("Running", true);
        } else {
            playerAnim.SetBool("Running", false);
        }

        transform.position += Vector3.right * speed * hInput * Time.deltaTime;
    }

    private void Jump(float multiplier) {
        playerRig.AddForce(new Vector2(0f, jumpHeight * multiplier), ForceMode2D.Impulse);
        playerAnim.SetBool("Jumping", true);
        isJumping = true;
    }

    private void Die() {
        playerAnim.SetBool("Alive", false);
        GameManager.Instance.GameOver();
    }
}
