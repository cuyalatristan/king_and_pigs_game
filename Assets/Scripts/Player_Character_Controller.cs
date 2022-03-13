using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Character_Controller : MonoBehaviour
{
    public Rigidbody2D rigidBody2D = null;
    public BoxCollider2D boxCollider2D = null;
    private Vector3 velocity = Vector3.zero;

    [Range(0f, 3f)]
    public float moveDownFactor = 0.0f;

    [Range(-1f,1f)]
    public float horizontalInput = 0f;
    [Range(-1f,1f)]
    public float verticalInput = 0f;
    public bool jumpInput = false;
    public float jumpForce = 1000f;
    public bool playerInput = true;
    public bool cameraFadeOut = false;
    public Easing.Type easing;
    public KingCharacterHearts kingCharacterHearts = null;
    public bool isDead = false;
    public bool attackInput = false;
    public bool isAttacking = false;
    public bool restartInput = false;

    void Start() {
        Camera.main.FadeIn(1.5f, easing);
    }

    // Update is called once per frame
    void Update() {
        this.isAttacking = false;
        this.verticalInput = rigidBody2D.velocity.y;
        if (playerInput) {
            this.horizontalInput = Input.GetAxisRaw("Horizontal");
            this.jumpInput = Input.GetKeyDown(KeyCode.Space);
            if (this.jumpInput && this.isGrounded) {
                this.rigidBody2D.AddForce(new Vector2(0f, jumpForce));
            }
            this.attackInput = Input.GetKeyDown(KeyCode.C);
            if (this.isGrounded && this.attackInput) {
                this.isAttacking = true;
            }
        } else {
            this.horizontalInput = 0f;
        }
        if (kingCharacterHearts != null) {
            if (kingCharacterHearts.heartsCurrent <= 0) {
            this.isDead = true;
            this.playerInput = false;
            } 
        }
        if (cameraFadeOut) {
            this.cameraFadeOut = !this.cameraFadeOut;
            Camera.main.FadeOut(1.5f, easing);
            StartCoroutine(LoadNewScene());
        }
        if (this.isDead) {
            this.restartInput = Input.GetKeyDown(KeyCode.Space);
            if (this.restartInput) {
                Scene currentScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currentScene.name);
            }
        }
    }

    IEnumerator LoadNewScene() {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Camera.main.FadeIn(1.5f, easing);
        this.playerInput = true;
    }

    void FixedUpdate() {
        this.UpdateGroundedStatus();
        {
            Vector3 targetVelocity = new Vector2(this.horizontalInput * 10f, this.rigidBody2D.velocity.y);
            this.rigidBody2D.velocity = Vector3.SmoothDamp(this.rigidBody2D.velocity, targetVelocity, ref velocity, this.moveDownFactor);
        }
        this.HandleFlip();
    }

    private bool facingRight = true;

    void HandleFlip() {
        if (this.horizontalInput > 0 && !facingRight) {
            Flip();
        } else if (this.horizontalInput < 0 && facingRight) {
            Flip();
        }
    }

    void Flip() {
        facingRight = !facingRight;

        Vector3 invertedScale = transform.localScale;
        invertedScale.x *= -1;

        transform.localScale = invertedScale;
    }

    [Header("Physics")]
    public Transform groundChecker = null;
    public bool isGrounded = false;
    public LayerMask groundCheckLayerMask;

    void UpdateGroundedStatus() {
        this.isGrounded = false;
        if (this.groundChecker != null) {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(this.groundChecker.transform.position, 0.2f, this.groundCheckLayerMask);
            if (colliders != null && colliders.Length > 0) {
                for (int i = 0; i < colliders.Length; i++) {
                    if (colliders[i].gameObject != this.gameObject) {
                        this.isGrounded = true;
                    }
                }
            }
        }
    }
}
