using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//This is attached to the Player, and will display different messages based on whichever object you are currently triggering in the scene.
public class MessageUI : MonoBehaviour
{
    public TextMeshPro displayArea;
    private Vector3 offset;

    public float xOffset = 0.0f;
    public float yOffset = 3.5f;

    
    void Start()
    {
        displayArea.enabled = false;
        displayArea.text = string.Empty;
        offset = new Vector3(xOffset, yOffset, 0.0f);
    }

    private void Update()
    {
        displayArea.rectTransform.position = transform.position + offset;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<DisplayMessage>() != null)
        {
            displayArea.text = collision.gameObject.GetComponent<DisplayMessage>().getMessage();
            displayArea.enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DisplayMessage>() != null)
        {
            displayArea.enabled = false;
        }
    }
}