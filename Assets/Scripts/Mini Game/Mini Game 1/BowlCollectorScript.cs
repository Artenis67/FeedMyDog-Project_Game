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
    [SerializeField] private GameOverUIScript gameOverUiScript;

    [Header("Life and Score")]
    public int life = 3;
    public int maxLife = 3;
    public int score;
    
    [Header("ToDisables")]
    [SerializeField] private Behaviour[] componentsToDisableWhenGameOver;
    
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
        gameOverUiScript.GameOver();
        
        foreach (var component in componentsToDisableWhenGameOver)
        {
            if (component)
            {
                component.enabled = false;
            }
        }
    }
}
