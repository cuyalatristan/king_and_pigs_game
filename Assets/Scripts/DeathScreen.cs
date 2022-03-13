using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    public Player_Character_Controller player_Character_Controller = null;
    // Start is called before the first frame update
    
    public Image blackScreen = null;
    public Text deathMessage = null;

    void Start() {
        this.Hide();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.player_Character_Controller.isDead) {
            this.Show();
        } else {
            this.Hide();
        }
    }

    void Show() {
        if (this.blackScreen != null) {
            this.blackScreen.gameObject.SetActive(true);
        }
        if (this.deathMessage != null) {
            this.deathMessage.gameObject.SetActive(true);
        }
    }

    void Hide() {
        if (this.blackScreen != null) {
            this.blackScreen.gameObject.SetActive(false);
        }
        if (this.deathMessage != null) {
            this.deathMessage.gameObject.SetActive(false);
        }
    }
}
