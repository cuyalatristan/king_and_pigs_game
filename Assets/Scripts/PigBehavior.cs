using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigBehavior : MonoBehaviour
{
    public Rigidbody2D rigidBody2d = null;
    public Animator animator = null;
    public Transform target = null;
    public SpriteRenderer spriteRenderer = null;
    public bool facingRight = false;
    public bool isDead = false;

    // Update is called once per frame
    void Update()
    {
        if (!this.isDead) {
            this.Flip();
            StartCoroutine(FlipAction());
        }
    }

    private void Flip()
    {
        if (transform.position.x < target.position.x) {
            this.facingRight = true;
        } else {
            this.facingRight = false;
        }
    }

    IEnumerator FlipAction() {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.1f);
        if (this.facingRight) {
            this.spriteRenderer.flipX = true;
        } else {
            this.spriteRenderer.flipX = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        float currentSize = 0;
        Player_Character_Controller player_Character_Controller = other.GetComponent<Player_Character_Controller>();
        Player_Character_Animations player_Character_Animations = other.GetComponent<Player_Character_Animations>();
        if (player_Character_Controller != null && !this.isDead) {
            currentSize = player_Character_Controller.boxCollider2D.size.x;
            string currentSizeString = currentSize.ToString("0.0");
            if (currentSizeString != "1.8") {
                player_Character_Controller.kingCharacterHearts.heartsCurrent -= 1;
                this.animator.SetTrigger("Attack");
                player_Character_Animations.animator.SetTrigger("IsHit");
            } else {
                this.animator.SetBool("IsDead",true);
                this.isDead = true;
            }
        }
    }
}
