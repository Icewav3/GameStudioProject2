using UnityEngine;


public class Plantable : MonoBehaviour
{
    public GameObject plantPrefab1;
    public GameObject plantPrefab2;
    public GameObject plantPrefab3;
    public GameObject plantInstance;
    public bool isPlanted;

    private PlayerController playerController;

    public void Start()
    {
        isPlanted = false;
        playerController = FindObjectOfType<PlayerController>();
    }

    public void SpawnPlant(GameObject plantPrefab)
    {
        plantInstance = Instantiate(plantPrefab, transform.position, Quaternion.identity, transform);
        isPlanted = true;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (!isPlanted && collision.gameObject.CompareTag("Player"))
        {
            if (playerController.plant1WasPressed)
            {
                SpawnPlant(plantPrefab1);
            }
            else if (playerController.plant2WasPressed)
            {
                SpawnPlant(plantPrefab2);
            }
            else if (playerController.plant3WasPressed)
            {
                SpawnPlant(plantPrefab3);
            }
        }
    }
}