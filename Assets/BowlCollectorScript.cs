using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlCollectorScript : MonoBehaviour
{
    [Header("Components")] 
    [SerializeField] private Collider2D collider2D;
    [SerializeField] private ScoreTextUIManager scoreTextUIManager;

    public int score;

    private void Start()
    {
        score = 0;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("CHOSE TOUCHE");
        
        if (other.gameObject.CompareTag("Kibble"))
        {
            Debug.Log("KIBBLE TOUCHE");
            
            IncreaseScore();
            
            Destroy(other.gameObject);
        }
    }

    private void IncreaseScore()
    {
        score = +1;
        
        scoreTextUIManager.SetScoreText(score);
    }
}
