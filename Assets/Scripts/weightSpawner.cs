using System.Collections.Generic;
using UnityEngine;

public class WeightSpawner : MonoBehaviour
{
    [SerializeField] private GameObject weightPrefab;
    [SerializeField] private Transform spawnPoint1;
    [SerializeField] private Transform spawnPoint2;

    [SerializeField] private float initialSpawnInterval = 4f;
    [SerializeField] private float spawnAccelerationRate = 0.95f;

    private float spawnTimer;
    private float currentSpawnInterval;
    private float elapsedTime;

    private List<GameObject> activeWeights = new List<GameObject>();

 

    private int spawnIndex = 0; 

    private void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        spawnTimer = currentSpawnInterval;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        elapsedTime += Time.deltaTime;
       

        if (spawnTimer <= 0f)
        {
            SpawnWeight();
            spawnTimer = currentSpawnInterval;
        }

        if (elapsedTime >= 15f)
        {
            currentSpawnInterval *= spawnAccelerationRate;
            elapsedTime = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RemoveOneRemovableWeight();
        }
    }

    private void SpawnWeight()
    {
        Transform chosenSpawn = (spawnIndex % 2 == 0) ? spawnPoint1 : spawnPoint2;
        GameObject weight = Instantiate(weightPrefab, chosenSpawn.position, Quaternion.identity);
        activeWeights.Add(weight);
        spawnIndex++;
    }

    private void RemoveOneRemovableWeight()
    {
        int removedCount = 0;

        for (int i = 0; i < activeWeights.Count; i++)
        {
            if (removedCount >= 2) break; //remove no máximo 2 pesos

            GameObject weight = activeWeights[i];
            if (weight == null) continue;

            Weight w = weight.GetComponent<Weight>();
            if (w != null && w.CanBeRemoved())
            {
                Destroy(weight);
                activeWeights.RemoveAt(i);
                i--; // corrige o índice após remover
                removedCount++;
            }
        }
    }

 
   

}
