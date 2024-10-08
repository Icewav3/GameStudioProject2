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

    public float xOffset = 0.0f;
    public float yOffset = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        textInstance = Instantiate(textPrefab);
        textInstance.SetActive(false);
        textToDisplay = textInstance.GetComponent<TMP_Text>();
        textToDisplay.text = text;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        textInstance.SetActive(true);
        MoveTextPosition();
    }

    private void OnTriggerExit2D()
    {
        textInstance.SetActive(false);
    }

    private void MoveTextPosition()
    {
        Vector3 textPosition = transform.position + new Vector3(yOffset, xOffset, 0);
    }
}
