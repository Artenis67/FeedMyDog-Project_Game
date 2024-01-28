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
        if (other.gameObject.CompareTag("Kibble"))
        {
            IncreaseScore();
        }
    }

    private void IncreaseScore()
    {
        score = +1;
        
        scoreTextUIManager.SetScoreText(score);
    }
}
