using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    public Animator animator = null;
    public Transform door = null;
    public Player_Character_Controller controller = null;
    public bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        if (this.animator != null) {
            this.animator.SetBool("Open", false);
        }
        this.open = false;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.open == true) {
            return;
        }
        KingCharacterInventory kingCharacterInventory = other.GetComponentInParent<KingCharacterInventory>();
        if (kingCharacterInventory != null) {
            if (kingCharacterInventory.diamondCount > 0) {
                kingCharacterInventory.diamondCount -= 1;
                this.open = true;
                print("opened");
                if (this.door != null) {
                    print(this.door.GetComponentInParent<Renderer>().bounds.center[0]);
                }
            }
        }
    }

    void LateUpdate() {
        if (this.animator != null) {
            if (this.open == true) {
                this.animator.SetBool("Open", true);
            }
        }
    }
}
