using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    private Animator transitionAnimator;

    [SerializeField] private float timeTransition;

    void Start()
    {
        transitionAnimator = GetComponentInChildren<Animator>();   
    }

    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex+1;
        StartCoroutine(SceneLoad(nextSceneIndex));
    }

    public IEnumerator SceneLoad(int sceneIndex)
    {
        transitionAnimator.SetTrigger("FadeTransition");
        yield return new WaitForSeconds(timeTransition);
        SceneManager.LoadScene(sceneIndex);
    }

    public void StartScene()
    {
        //Debug.Log("Al inicio");
        StartCoroutine(SceneStart(0));
    }

    private IEnumerator SceneStart(int v)
    {
        transitionAnimator.SetTrigger("FadeTransition");
        yield return new WaitForSeconds(timeTransition);
        SceneManager.LoadScene(v);
    }
}
