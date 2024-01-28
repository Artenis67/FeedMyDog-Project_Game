using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextUIManager : MonoBehaviour
{
    [Header("Components")] 
    [SerializeField] private Text scoreText;

    public void SetScoreText(int _score)
    {
        scoreText.text = _score.ToString();
    }
}
