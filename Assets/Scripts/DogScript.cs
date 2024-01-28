using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DogScript : MonoBehaviour
{
    [Header("Animation System")] 
    [SerializeField] private Animator animator;
    [SerializeField] private string runParameterName;

    [Header("Positions")] 
    [SerializeField] private Vector3 startAnimPosition;
    [SerializeField] private Vector3 endAnimPosition;

    [Header("Components")] 
    [SerializeField] private GameManager _gameManager;

    private void Awake()
    {
        if (!_gameManager)
        {
            Debug.LogError("Game Manager missing in Dog !");
        }
    }

    void Start()
    {
        CheckTypeOfDog();
    }

    void CheckTypeOfDog()
    {
        if (_gameManager.KitchenAnimPart1)
        {
            StartCoroutine(KitchenAnimationPart1Sys(startAnimPosition, endAnimPosition, 1.25f));
        }
    }

    IEnumerator KitchenAnimationPart1Sys(Vector3 start, Vector3 end, float duration)
    {
        float startTime = Time.time;
        float journeyLength = Vector3.Distance(start, end);

        while (Time.time - startTime < duration)
        {
            float distCovered = (Time.time - startTime) * (journeyLength / duration);
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(start, end, fracJourney);
            
            animator.SetBool(runParameterName, true);
            
            yield return null;
        }

        // Assurez-vous que l'objet est exactement à la position d'arrivée à la fin
        transform.position = end;

        animator.SetBool(runParameterName, false);
    }
}
