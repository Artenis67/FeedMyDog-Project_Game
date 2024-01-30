using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUIScript : MonoBehaviour
{
    [Header("Components")] 
    [SerializeField] private BowlCollectorScript bowlCollectorScript;
    
    [Header("UI Composents")] 
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject scoreUI;
    [SerializeField] private Text endScoreText;
    
    [Header("Animation Systeme")]
    [SerializeField] private AnimationClip sceneTransitionAnimation;
    [SerializeField] private Animation animation;

    private void Start()
    {
        animation = GetComponent<Animation>();
    }

    public void GameOver()
    {
        scoreUI.SetActive(false);
        gameOverUI.SetActive(true);
        
        animation.Play(sceneTransitionAnimation.name);

        endScoreText.text = "+ " + bowlCollectorScript.score.ToString();
    }
}
