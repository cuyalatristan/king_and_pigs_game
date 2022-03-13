using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingCharacterKeyCount : MonoBehaviour
{
    [SerializeField] private KingCharacterInventory kingCharacterInventory = null;
    public KingCharacterInventory kingCharacterInventoryPublic
    {
        get
        {
            if (this.kingCharacterInventory == null)
                this.kingCharacterInventory = this.gameObject.GetComponentInParent<KingCharacterInventory>();
            return this.kingCharacterInventory;
        }
    }

    [Header("UI References")]
    public Image keyImage = null;
    public Text keyText = null;

    void Update()
    {
        if (this.kingCharacterInventoryPublic != null && this.kingCharacterInventoryPublic.diamondCount > 0)
        {
            // Show
            this.Show();

            // Update
            if (this.keyText != null)
                this.keyText.text = this.kingCharacterInventoryPublic.diamondCount.ToString();
        }
        else
        {
            // Hide view
            this.Hide();
        }
    }

    void Show()
    {
        if (this.keyImage != null)
            this.keyImage.gameObject.SetActive(true);
        if (this.keyText != null)
            this.keyText.gameObject.SetActive(true);
    }

    void Hide()
    {
        if (this.keyImage != null)
            this.keyImage.gameObject.SetActive(false);
        if (this.keyText != null)
            this.keyText.gameObject.SetActive(false);
    }
}
