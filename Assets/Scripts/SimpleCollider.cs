using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCollider : MonoBehaviour
{
    private SceneStateManager sceneStateManager;
    private UIManager uiManager;

    private void Start()
    {
        sceneStateManager = FindObjectOfType<SceneStateManager>();
        uiManager = FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            sceneStateManager.PauseGame();
            uiManager.LoadLoseUI();
            SceneStateManager.playerLost = true;
        }
    }
}
