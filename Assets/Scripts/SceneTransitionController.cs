using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionController : MonoBehaviour
{
    [SerializeField] private AnimationClip sceneTransitionAnimation;
    [SerializeField] private string nextSceneName;
    [SerializeField] private AudioSource audioSource;

    private Animation animation;

    void Start()
    {
        animation = GetComponent<Animation>();
        StartCoroutine(PlaySceneTransitionAnimation());
    }

    private IEnumerator PlaySceneTransitionAnimation()
    {
        animation.Play(sceneTransitionAnimation.name);

        yield return new WaitForSeconds(sceneTransitionAnimation.length - 0.3f);
        
        audioSource.Play();
        
        yield return new WaitForSeconds(1);

        LoadNextScene();
    }

    void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}