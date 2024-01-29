using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BowlCollectorScript : MonoBehaviour
{
    [Header("Components")] 
    [SerializeField] private ScoreTextUIManager scoreTextUIManager;
    [SerializeField] private LifeUISystem lifeUISystem;
    
    public int life = 3;
    public int maxLife = 3;
    public int score;

    private void Start()
    {
        life = maxLife;
        
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

    public void StealOneLife()
    {
        if (life > 1)
        {
            life--;
        }
        else
        {
            GameOver();
        }
        
        lifeUISystem.StealOneHeart();
    }

    private void GameOver()
    {
        Debug.LogError("GAME OVER !");
    }

    private void Update()
    {
        Debug.Log(life);
    }
}
