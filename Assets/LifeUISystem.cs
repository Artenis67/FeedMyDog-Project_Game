using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LifeUISystem : MonoBehaviour
{
    [Header("Hearts")] 
    [SerializeField] private GameObject heart1;
    [SerializeField] private GameObject heart2;
    [SerializeField] private GameObject heart3;

    private int activeHeartCounter;

    private void Start()
    {
        activeHeartCounter = 3;
    }

    public void StealOneHeart()
    {
        activeHeartCounter--;
        
        if(activeHeartCounter == 3) {heart1.SetActive(true); heart2.SetActive(true); heart3.SetActive(true);}
        
        if(activeHeartCounter == 2) {heart1.SetActive(true); heart2.SetActive(true); heart3.SetActive(false);}
        
        if(activeHeartCounter == 1) {heart1.SetActive(true); heart2.SetActive(false); heart3.SetActive(false);}
        
        if(activeHeartCounter == 0) {heart1.SetActive(false); heart2.SetActive(false); heart3.SetActive(false);}

    }
}
