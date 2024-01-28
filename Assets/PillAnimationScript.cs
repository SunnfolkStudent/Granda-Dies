using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PillAnimationScript : MonoBehaviour
{
    public GameObject pillBoxClosed;
    public GameObject animation;
    public Animator animator;
    [SerializeField] private string _scene;
    public GameObject canvas;

    public void playAnimation()
    {
        if (pillBoxClosed.activeSelf == false)
        {
            StartCoroutine(AnimationAndEnd());
            
        }
        else
        {
            return;
        }
        
    }

    IEnumerator AnimationAndEnd()
    {
        canvas.SetActive(false);
        animation.SetActive(true);
        animator.Play("Pill minigame animation_Clip");
        yield return new WaitForSeconds(2f);
        SceneManager.UnloadSceneAsync(_scene);
        PlayerController.canMove = true;
    }

    private void Update()
    {
        
    }
}
