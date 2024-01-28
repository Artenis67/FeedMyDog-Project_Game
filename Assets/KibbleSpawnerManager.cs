using System;
using System.Collections;
using System.Collections.Generic;
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

    private void Update()
    {
        SpawnRandomlyKibble();
    }

    private void SpawnRandomlyKibble()
    {
        // Générer un indice aléatoire entre 1 et 5
        int randomIndex = Random.Range(1, 6);

        // Choisir le spawner correspondant à l'indice aléatoire
        GameObject selectedSpawner = null;

        switch (randomIndex)
        {
            case 1:
                selectedSpawner = spawner1;
                break;
            case 2:
                selectedSpawner = spawner2;
                break;
            case 3:
                selectedSpawner = spawner3;
                break;
            case 4:
                selectedSpawner = spawner4;
                break;
            case 5:
                selectedSpawner = spawner5;
                break;
            default:
                Debug.LogError("Invalid random index");
                break;
        }
        
        if (!selectedSpawner)
        {
            GameObject newKibble = Instantiate(kibblePrefab);
            
            Destroy(newKibble, 3f);
        }
    }
}
