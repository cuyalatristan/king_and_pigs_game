using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool spaceInput = false;
    public Easing.Type easing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "IntroScene" || SceneManager.GetActiveScene().name == "ControlsScene" || SceneManager.GetActiveScene().name == "StoryScene") {
            this.spaceInput = Input.GetKeyDown(KeyCode.Space);
            if (this.spaceInput) {
                Camera.main.FadeOut(1.5f, easing);
                StartCoroutine(LoadNewScene());
            }
        }
    }

    IEnumerator LoadNewScene() {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Camera.main.FadeIn(1.5f, easing);
    }
}
