using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class FogBehaviour : MonoBehaviour
{
    [SerializeField]
    private SimpleFogController _controller;

    // Start is called before the first frame update
    void Start()
    {
        _controller = FindObjectOfType<SimpleFogController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blocker"))
        {
            if (collision.gameObject.transform.position.x > 0)
            {
                _controller.isBlockedRight = true;
            }
            else
            {
                _controller.isBlockedLeft = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blocker"))
        {
            if (collision.gameObject.transform.position.x > 0)
            {
                _controller.isBlockedRight = true;
            }
            else
            {
                _controller.isBlockedLeft = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blocker"))
        {
            if (collision.gameObject.transform.position.x > 0)
            {
                _controller.isBlockedRight = false;
            }
            else
            {
                _controller.isBlockedLeft = false;
            }
        }
    }
}
