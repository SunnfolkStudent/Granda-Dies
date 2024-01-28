using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BottleMinigameScript : MonoBehaviour
{
    public GameObject bottle;
    public GameObject bottle2;
    public GameObject animation;
    public Image Image;
    public Sprite sprite;
    public Animator animator;
    public float timer1 = 0;
    public float timer2 = 0;
    private bool ahhhhhh;
    
    public void BottleAnimation()
    {
        bottle.SetActive(false);
        animation.SetActive(true);
        animator.Play("Stream startup");
        ahhhhhh = true;
    }

    private void Update()
    {
        if (ahhhhhh)
        {
            timer1 += 0.5f * Time.deltaTime;
        }
        
        if (timer1 > 1)
        {
            Image.overrideSprite = sprite;
            bottle2.SetActive(false);
            ahhhhhh = false;
            
            timer2 += 0.33f * Time.deltaTime;
        }

        if (timer2 > 1)
        {
            SceneManager.UnloadSceneAsync("Bottle Minigame");
            Debug.Log("unloading");
            PlayerController.canMove = true;
            var temp = GameObject.FindWithTag("Grandpa");
        }
    }
}
