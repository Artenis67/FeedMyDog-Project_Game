using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score;
    
    [Header("TypeOfDog")] 
    public bool KitchenAnimPart1;
    public bool KitchenAnimPart2;
    public bool KitchenAnimPart3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
