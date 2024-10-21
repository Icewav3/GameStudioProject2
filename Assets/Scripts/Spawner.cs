using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class Spawner : MonoBehaviour
    {
        [Header("Spawn Settings")] [Tooltip("Array of prefabs to spawn")] [SerializeField]
        private GameObject[] prefabs; // Array of prefabs to spawn

        [Tooltip("Initial minimum prefabs per wave")]
        private int initialMinPrefabsPerWave = 1;

        [Tooltip("Initial maximum prefabs per wave")]
        private int initialMaxPrefabsPerWave = 3;

        [Tooltip("Multiplies all spawns")]
        private float difficultyMultiplier = 1.1f;

        [Tooltip("In seconds")]
        private float waveCooldown = 15f;
        
        [Tooltip("enemies added per wave")]
        private int enemiesPerWave = 1;

        [Tooltip("Initial delay before starting spawning (seconds)")] 
        private float initialWaveDelay = 30f;

        private int currentWave = 0; // Current wave counter
        private bool isSpawning = false;

        private int minPrefabsPerWave;
        private int maxPrefabsPerWave;

        private void Start()
        {
            // Initialize wave settings
            minPrefabsPerWave = initialMinPrefabsPerWave;
            maxPrefabsPerWave = initialMaxPrefabsPerWave;
            

            // Optionally start spawning immediately
            StartSpawning();
        }

        public void StartSpawning()
        {
            if (!isSpawning)
            {
                isSpawning = true;
                StartCoroutine(InitialDelayAndSpawnWaves());
            }
        }

        public void StopSpawning()
        {
            if (isSpawning)
            {
                isSpawning = false;
                StopCoroutine(SpawnWaves());
            }
        }

        private IEnumerator InitialDelayAndSpawnWaves()
        {
            yield return new WaitForSeconds(initialWaveDelay);
            StartCoroutine(SpawnWaves());
        }

        private IEnumerator SpawnWaves()
        {
            while (isSpawning)
            {
                currentWave++;
                int prefabsToSpawn = Random.Range(minPrefabsPerWave, maxPrefabsPerWave) + currentWave * enemiesPerWave;
                for (int i = 0; i < prefabsToSpawn; i++)
                {
                    SpawnPrefab();
                }

                AdjustDifficulty();
                yield return new WaitForSeconds(waveCooldown);
            }
        }

        private void SpawnPrefab()
        {
            if (prefabs.Length == 0)
            {
                Debug.LogError("No prefabs assigned to the spawner.");
                return;
            }

            GameObject prefabToSpawn = prefabs[Random.Range(0, prefabs.Length)];
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        }

        private void AdjustDifficulty()
        {
            minPrefabsPerWave = Mathf.CeilToInt(minPrefabsPerWave * difficultyMultiplier);
            maxPrefabsPerWave = Mathf.CeilToInt(maxPrefabsPerWave * difficultyMultiplier);
        }
    }
}