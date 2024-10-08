using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlantStates {Ready, Plant1, Plant2, Plant3, Growing}

public class Planting : MonoBehaviour
{
    public PlantStates currentPlantState;

    public GameObject plantPrefab1;
    public GameObject plantPrefab2;
    public GameObject plantPrefab3;
    public GameObject plantInstance;
    public float scaleFactor = 1.0001f;

    public float timer = 0.0f;
    public float plant1Time = 3.0f;
    public float plant2Time = 3.0f;
    public float plant3Time = 3.0f;
    public bool isPlanted = false;
    public PlayerController playerController;

    public void Start()
    {
        currentPlantState = PlantStates.Ready;
    }
    public void Update()
    {
        timer += Time.deltaTime;

            switch (currentPlantState)
            {
                case PlantStates.Ready:
                    EnterReadyState();
                    break;

                case PlantStates.Plant1:
                    EnterPlant1State();
                    break;

                case PlantStates.Plant2:
                    EnterPlant2State();
                    break;

                case PlantStates.Plant3:
                    EnterPlant3State();
                    break;

                case PlantStates.Growing:
                    EnterGrowingState();
                    break;
            }
    }

    public void SetPlantState()
    {
        switch (currentPlantState)
        {
            case PlantStates.Ready:
                currentPlantState = PlantStates.Plant1;
                break;

            case PlantStates.Plant1:
                currentPlantState = PlantStates.Plant2;
                break;

            case PlantStates.Plant2:
                currentPlantState = PlantStates.Plant3;
                break;

            case PlantStates.Plant3:
                currentPlantState = PlantStates.Growing;
                break;
        }
        timer = 0.0f;
        isPlanted = false;
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (!isPlanted)
        {
            if (currentPlantState == PlantStates.Ready && playerController.plantWasPressed)
            {
                isPlanted = true;
                playerController.plantWasPressed = false;
                SetPlantState();
            }
        }
    }

    public void EnterReadyState() 
    { 

    }
    public void EnterPlant1State() 
    {
        if (!isPlanted)
        {
            plantInstance = Instantiate(plantPrefab1, transform.position, Quaternion.identity);
            isPlanted = true;
        }
        if(timer > plant1Time)
        {
            SetPlantState();
        }
    }
    public void EnterPlant2State() 
    {
        if (!isPlanted)
        {
            Destroy(plantInstance);
            plantInstance = Instantiate(plantPrefab2, transform.position, Quaternion.identity);
            isPlanted = true;
        }
        if (timer > plant2Time)
        {
            SetPlantState();
        }
    }
    public void EnterPlant3State() 
    {
        if (!isPlanted)
        {
            Destroy(plantInstance);
            plantInstance = Instantiate(plantPrefab3, transform.position, Quaternion.identity);
            isPlanted = true;
        }
        if (timer > plant3Time)
        {
            SetPlantState();
        }
    }
    public void EnterGrowingState() 
    {
        plantInstance.transform.localScale *= scaleFactor;
    }


}
