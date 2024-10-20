using UnityEngine;


public class Plantable : MonoBehaviour
{
    public GameObject plantInstance;
    public bool isPlanted;

    public void Start()
    {
        isPlanted = false;
    }

    public void SpawnPlant(GameObject plantPrefab)
    {
        plantInstance = Instantiate(plantPrefab);
        isPlanted = true;
    }
}