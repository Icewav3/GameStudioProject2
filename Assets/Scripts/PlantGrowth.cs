using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    //Maybe toggle these from the collider scripts for the plants to control their growth?
    public bool canGrow;
    public bool canShrink;

    [SerializeField]
    private float growFactor = 1.0001f;
    [SerializeField]
    private float shrinkFactor = 1.001f;
    [SerializeField]
    private float maxPlantScale = 2.0f;



    // Start is called before the first frame update
    void Start()
    {
        canGrow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canGrow)
        {
            growPlant();
        }
        else if(canShrink)
        {
            shrinkPlant();
        }
    }

    private void growPlant()
    {
        //When the plant Animation has reached the full-grown stage, then we can scale the plant up
        if (transform.localScale.y <= maxPlantScale)//Add in canGrow when we have that set up
        {
            transform.localScale *= growFactor;
        }
    }
    private void shrinkPlant()
    {
        transform.localScale /= shrinkFactor;
    }
}
