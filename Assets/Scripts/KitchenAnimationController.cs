using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenAnimationController : MonoBehaviour
{
    [Header("AnimationsClips")] 
    [SerializeField] private AnimationClip fallingKibbleAnimClip;
    [SerializeField] private AnimationClip cameraZoomAnimClip;
    
    [Header("Animation")] 
    [SerializeField] private Animation cameraAnimation;
    private Animation animation;

    private void Awake()
    {
        animation = GetComponent<Animation>();
    }

    private void Start()
    {
        StartCoroutine(DoAnimation());
    }

    public IEnumerator DoAnimation()
    {
        yield return new WaitForSeconds(1.2f);

        cameraAnimation.Play(cameraZoomAnimClip.name);

        yield return new WaitForSeconds(1f);
        
        animation.Play(fallingKibbleAnimClip.name);
    }
}
