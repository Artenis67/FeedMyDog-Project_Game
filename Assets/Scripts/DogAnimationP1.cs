using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DogAnimationP1 : MonoBehaviour
{
    [Header("Animation System")] 
    [SerializeField] private Animator animator;
    [SerializeField] private string runParameterName;

    [Header("Positions")] 
    [SerializeField] private Vector3 startAnimPosition;
    [SerializeField] private Vector3 endAnimPosition;

    void Start()
    {
        StartCoroutine(KitchenAnimationPart1Sys(startAnimPosition, endAnimPosition, 1.25f));
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

        transform.position = end;

        animator.SetBool(runParameterName, false);
    }
}