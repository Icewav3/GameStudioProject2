using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


    // https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadScene.html
public class QuitAndReset : MonoBehaviour
{
    public KeyCode quitKey = KeyCode.Escape;
    public KeyCode resetKey = KeyCode.R;

    public int sceneIndexToLoad = 0;

    private void Update() {
        if (Input.GetKeyDown(quitKey)) {
            Application.Quit();
        }

        if(Input.GetKeyDown(resetKey)) {
            SceneManager.LoadScene(sceneIndexToLoad);
        }
    }
}
