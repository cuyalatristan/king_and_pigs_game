using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCenter : MonoBehaviour
{
    public Transform door = null;
    public Player_Character_Controller controller = null;
    public Player_Character_Animations animations = null;

    void OnTriggerEnter2D(Collider2D other) {
        if (this.GetComponentInParent<DoorLock>().open == true) {
            this.controller.playerInput = false;
            this.animations.isEntering = true;
            this.controller.cameraFadeOut = true;
        }
    }
}
