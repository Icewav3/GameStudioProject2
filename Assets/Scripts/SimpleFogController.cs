using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFogController : MonoBehaviour
{
    [SerializeField]
    private GameObject fogObjectLeft;
    [SerializeField]
    private GameObject fogObjectRight;
    [Tooltip("Time in seconds for the fog to close in")]
    [SerializeField]
    private float timeToTravel = 180;
    private Vector3 endPoint;
    private Vector3 distanceToEndPoint;

    public bool isBlockedLeft;
    public bool isBlockedRight;


    void Start()
    {
        endPoint = Vector3.zero;
        distanceToEndPoint = endPoint - fogObjectLeft.transform.position;
        isBlockedLeft = false;
        isBlockedRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isBlockedLeft)
        {
            fogObjectLeft.transform.position += distanceToEndPoint * Time.deltaTime / timeToTravel;
        }
        if (!isBlockedRight)
        {
            fogObjectRight.transform.position += (distanceToEndPoint * -1) * Time.deltaTime / timeToTravel;
        }
    }
}
