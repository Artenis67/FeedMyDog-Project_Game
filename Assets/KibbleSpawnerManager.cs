using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class KibbleSpawnerManager : MonoBehaviour
{
    [Header("Kibble Spawners")] 
    [SerializeField] private GameObject spawner1;
    [SerializeField] private GameObject spawner2;
    [SerializeField] private GameObject spawner3;
    [SerializeField] private GameObject spawner4;
    [SerializeField] private GameObject spawner5;

    [Header("Kibble Prefab")] 
    [SerializeField] private GameObject kibblePrefab;

    private bool onIsSpawn = false;
    [SerializeField] private int globalSpawnCounter;
    [SerializeField] private float maxSpeedSpawn = 5;

    private void Start()
    {
        globalSpawnCounter = 0;
    }

    private void FixedUpdate()
    {
        if (!onIsSpawn)
        {
            StartCoroutine(WaitAndSpawnKibble());
        }

        UpdateTimerWithScore();
    }
    
    private IEnumerator WaitAndSpawnKibble()
    {
        onIsSpawn = true;
        
        yield return new WaitForSeconds(Random.Range(0.5f, maxSpeedSpawn));
        
        // Générer un indice aléatoire entre 1 et 5
        int randomIndex = Random.Range(1, 6);

        // Choisir le spawner correspondant à l'indice aléatoire
        GameObject selectedSpawner = null;

        if (randomIndex == 1)
        {
            selectedSpawner = spawner1;
        }
        if (randomIndex == 2)
        {
            selectedSpawner = spawner2;
        }
        if (randomIndex == 3)
        {
            selectedSpawner = spawner3;
        }
        if (randomIndex == 4)
        {
            selectedSpawner = spawner4;
        }
        if (randomIndex == 5)
        {
            selectedSpawner = spawner5;
        }
        if (selectedSpawner)
        {
            GameObject newKibble = Instantiate(kibblePrefab, selectedSpawner.transform.position, quaternion.identity);
            
            Destroy(newKibble, 3f);
        }
        
        onIsSpawn = false;
        globalSpawnCounter += 1;
    }

    private void UpdateTimerWithScore()
    {
        if (globalSpawnCounter > 10)
        {
            if (globalSpawnCounter > 20)
            {
                if (globalSpawnCounter > 30)
                {
                    if (globalSpawnCounter > 40)
                    {
                        if (globalSpawnCounter > 50)
                        {
                            maxSpeedSpawn = 1f;
                        }
                        else
                        {
                            maxSpeedSpawn = 2f;
                        }
                    }
                    else
                    {
                        maxSpeedSpawn = 2.5f;
                    }
                }
                else
                {
                    maxSpeedSpawn = 3f;
                }
            }
            else
            {
                maxSpeedSpawn = 3.5f;
            }
        }
        else
        {
            maxSpeedSpawn = 4f;
        }
    }
}