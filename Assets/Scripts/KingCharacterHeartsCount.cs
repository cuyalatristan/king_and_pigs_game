using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingCharacterHeartsCount : MonoBehaviour
{
    [SerializeField] private KingCharacterHearts kingCharacterHearts = null;

    public KingCharacterHearts kingCharacterHeartsPublic
    {
        get
        {
            if (this.kingCharacterHearts == null)
                this.kingCharacterHearts = this.gameObject.GetComponentInParent<KingCharacterHearts>();
            return this.kingCharacterHearts;
        }
    }

    [Header("UI References")]    
    public Image heart1 = null;
    public Image heart2 = null;
    public Image heart3 = null;
    // Update is called once per frame
    void Update()
    {
        if (this.kingCharacterHeartsPublic != null && this.kingCharacterHeartsPublic.heartsCurrent >= 0) {
            if (this.kingCharacterHeartsPublic.heartsCurrent == 2) {
                this.heart3.gameObject.SetActive(false);
            }
            if (this.kingCharacterHeartsPublic.heartsCurrent == 1) {
                this.heart2.gameObject.SetActive(false);
            }
            if (this.kingCharacterHeartsPublic.heartsCurrent == 0) {
                this.heart1.gameObject.SetActive(false);
            }
        }
    }
}
