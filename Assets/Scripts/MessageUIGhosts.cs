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
    public GameObject target;
    private GameObject[] ghosts;
    private List<float> floats;
    public float xOffset = 0.0f;
    public float yOffset = 3.5f;

    private bool hasNegative;
    private bool hasPositive;


    void Start()
    {
        displayIconLeft.SetActive(false);
        displayIconRight.SetActive(false);
        floats = new List<float>();
    }

    private void Update()
    {
        offset = new Vector3(xOffset, yOffset, 0.0f);
        displayIconLeft.transform.position = target.transform.position - offset;
        displayIconRight.transform.position = target.transform.position + offset;
        ghosts = GameObject.FindGameObjectsWithTag("Enemy");
        if(ghosts.Length > 0)
        {
            GetGhostPositions();
            floats.Clear();
        }
        ToggleIcon();
    }

    private void ToggleIcon()
    {
        if (hasNegative)
        {
            displayIconLeft.SetActive(true);
        }
        else
        {
            displayIconLeft.SetActive(false);
        }
        if (hasPositive)
        {
            displayIconRight.SetActive(true);
        }
        else
        {
            displayIconRight.SetActive(false);
        }
    }
    private void GetGhostPositions()
    {
        hasPositive = false;
        hasNegative = false;

        for(int g = 0; g < ghosts.Length; g++) {
            floats.Add(ghosts[g].transform.position.x);

        }
        for(int i = 0; i < floats.Count; i++)
        {
            if (floats[i] > displayIconRight.transform.position.x)
            {
                hasPositive = true;
            }
            else if (floats[i] < displayIconLeft.transform.position.x)
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
