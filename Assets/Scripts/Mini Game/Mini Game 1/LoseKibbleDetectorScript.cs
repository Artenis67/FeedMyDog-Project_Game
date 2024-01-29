using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseKibbleDetectorScript : MonoBehaviour
{
    [Header("Components")] 
    [SerializeField] private BowlCollectorScript bowlCollectorScript;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Kibble"))
        {
            bowlCollectorScript.StealOneLife();
            
            Destroy(other);
        }
    }
}
