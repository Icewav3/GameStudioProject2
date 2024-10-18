using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera centerCam;
    public CinemachineVirtualCamera rightCam;
    public CinemachineVirtualCamera leftCam;

    public PlayerController player;
    private float playerInput;

    private void Start()
    {
        centerCam.enabled = true;
        leftCam.enabled = false;
        rightCam.enabled = false;
    }

    private void Update()
    {
        playerInput = player.moveInput;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (playerInput == 0)
        {
            centerCam.enabled = true;
            leftCam.enabled = false;
            rightCam.enabled = false;
        }
        else if (playerInput > 0)
        {
            centerCam.enabled = false;
            leftCam.enabled = false;
            rightCam.enabled = true;
        }
        else if (playerInput < 0)
        {
            centerCam.enabled = false;
            leftCam.enabled = true;
            rightCam.enabled = false;
        }
    }
}
