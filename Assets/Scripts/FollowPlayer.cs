using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float yOffset = 1.0f;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.position + new Vector3(0, yOffset, -10);
    }
}
