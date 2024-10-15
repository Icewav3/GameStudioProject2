using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayName : MonoBehaviour
{
    public GameObject textPrefab;
    private GameObject textInstance;
    private TMP_Text textToDisplay;
    public string text = string.Empty;
    private GameObject canvas;
    public Planting planting;

    public float xOffset = 0.0f;
    public float yOffset = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        textInstance = Instantiate(textPrefab, canvas.transform);
        textInstance.SetActive(false);
        textToDisplay = textInstance.GetComponent<TMP_Text>();
        textToDisplay.text = text;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !(planting.isPlanted))
        {
            textInstance.SetActive(true);
            MoveTextPosition();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(planting.isPlanted)
        {
            textInstance.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && textInstance != null)
        {
            textInstance.SetActive(false);
        }
    }

    private void MoveTextPosition()
    {
        Vector3 textPosition = canvas.transform.position + new Vector3(xOffset, yOffset, 0);

        RectTransform rectTransform = textInstance.GetComponent<RectTransform>();
        rectTransform.position = textPosition;
    }
}
