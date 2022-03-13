using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private bool canBeGrabbed = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.canBeGrabbed == false)
        return;

        KingCharacterInventory kingCharacterInventory = other.GetComponentInParent<KingCharacterInventory>();
        if (kingCharacterInventory != null) {
            kingCharacterInventory.diamondCount += 1;
            this.canBeGrabbed = false;
            GameObject.Destroy(this.gameObject);
        }
    }
}
