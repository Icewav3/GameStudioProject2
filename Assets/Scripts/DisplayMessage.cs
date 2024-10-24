using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMessage : MonoBehaviour
{
    public bool canDisplayMessage = true;
    public string messageToShow;

    private void Update()
    {
        
    }

    public string getMessage()
    {
        return messageToShow;
    }

}
