using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Character_Animations : MonoBehaviour
{
    public Player_Character_Controller playerCharacterController = null;

    public float HorizontalInput {
        get{
            if (playerCharacterController != null) {
                return this.playerCharacterController.horizontalInput;
            }
            return 0f;
        }
    }

    public float VerticalInput {
        get{
            if(playerCharacterController != null) {
                return this.playerCharacterController.verticalInput;
            }
            return 0f;
        }
    }

    public bool IsDead {
        get{
            if(playerCharacterController != null) {
                return this.playerCharacterController.isDead;
            }
            return false;
        }
    }

    public bool IsAttacking {
        get{
            if(playerCharacterController != null) {
                return this.playerCharacterController.isAttacking;
            }
            return false;
        }
    }

    public bool isEntering = false;

    public Animator animator = null;

    // Update is called once per frame
    void LateUpdate()
    {
        if (this.animator != null) {
            this.animator.SetFloat("Horizontal", Mathf.Abs(this.HorizontalInput));
            this.animator.SetFloat("Vertical", this.VerticalInput);
            this.animator.SetBool("IsEntering", this.isEntering);
            this.animator.SetBool("IsDead", this.IsDead);
            if (this.IsAttacking) {
                this.animator.SetTrigger("IsAttacking");
            }
        }
    }
}
