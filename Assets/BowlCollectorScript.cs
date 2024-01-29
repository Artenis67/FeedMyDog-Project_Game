using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BowlCollectorScript : MonoBehaviour
{
    [Header("Components")] 
    [SerializeField] private ScoreTextUIManager scoreTextUIManager;

    public int score;

    private void Start()
    {
        score = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Kibble"))
        {
            IncreaseScore();
            
            Destroy(other.gameObject);
        } 
    }

    private void IncreaseScore()
    {
        score++;
        
        scoreTextUIManager.SetScoreText(score);
    }
}
