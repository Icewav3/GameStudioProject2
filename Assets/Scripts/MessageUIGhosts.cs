using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//This is attached to the Player, and will display different messages based on whichever object you are currently triggering in the scene.
public class MessageUIGhosts : MonoBehaviour
{
    private Vector3 offset;

    public GameObject displayIconLeft;
    public GameObject displayIconRight;
    private GameObject[] ghosts;
    private List<float> floats;
    private Camera mainCam;

    private bool hasNegative;
    private bool hasPositive;


    void Start()
    {
        mainCam = Camera.main;
        displayIconLeft.SetActive(false);
        displayIconRight.SetActive(false);
        floats = new List<float>();
    }

    private void Update()
    {

        ghosts = GameObject.FindGameObjectsWithTag("Enemy");
        if(ghosts.Length == 0)
        {
            hasPositive = false;
            hasNegative = false;
        }
        else
        {
            GetGhostPositions();
        }
        ToggleIcon();
    }

    private void ToggleIcon()
    {
        if (displayIconLeft != null)
        {
            displayIconLeft.SetActive(hasNegative);
        }

        if (displayIconRight != null)
        {
            displayIconRight.SetActive(hasPositive);
        }
    }
    private void GetGhostPositions()
    {
        floats.Clear();
        hasPositive = false;
        hasNegative = false;

        Vector3 leftBound = mainCam.ViewportToWorldPoint(new Vector3(0, 0, mainCam.nearClipPlane));
        Vector3 rightBound = mainCam.ViewportToWorldPoint(new Vector3(1, 0, mainCam.nearClipPlane));

        for (int g = 0; g < ghosts.Length; g++) {
            floats.Add(ghosts[g].transform.position.x);

        }
        for(int i = 0; i < floats.Count; i++)
        {
            if (floats[i] > rightBound.x)
            {
                hasPositive = true;
            }
            else if (floats[i] < leftBound.x)
            {
                hasNegative = true;
            }
            if(hasNegative && hasPositive)
            {
                break;
            }
        }
    }
}
