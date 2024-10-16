using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float yOffset = 1.0f;
    private Vector3 mousePos;
    private Camera _mainCam;

    private void Start()
    {
        _mainCam = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        mousePos = Input.mousePosition; //TODO make it stick to the player more
        //TODO test out camera movement regarding shifting player to the edge while moving to increase forward vision
        Vector2 targetPosition = _mainCam.ScreenToWorldPoint(Input.mousePosition); //convert to world coordinates
        transform.position = player.position + new Vector3((0+targetPosition.x/2), yOffset, -10);
    }
}
