using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GrandpaManager : MonoBehaviour
{

    [SerializeField] private AudioSource backgroundMusicSource;
    
    private Animator animator;
    private AudioSource audioSource;
    private String currPlay;

    [Header("Death Modifiers")] 
    public bool grandpaInfusedWithPiss; 
    public bool dead;
    
    [Header("Health")]
    public int grandpaHealth;

    private DeathManager deathManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        deathManager = GetComponent<DeathManager>();
        currPlay = "breathe no pee";
        grandpaHealth = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (grandpaHealth == 0 && !grandpaInfusedWithPiss)
        {
            dead = true;
            GrandpaIsFuckingDead();
        }
        else if (grandpaHealth == 0 && grandpaInfusedWithPiss)
        {
            dead = true;
            GrandpaIsFuckingDeadAndPissInfused();
        }

        if (grandpaHealth == 0 && !deathManager.timerActive)
        {
            deathManager.startDeathTimer();
            audioSource.Play();
            grandpaHealth--;
        }
    }

    #region -----Animations-----
    public void InfuseWithPiss()
    {
        animator.SetTrigger("aliveAndPissInfused");
        grandpaInfusedWithPiss = true;
        currPlay = "breathe pee";
        return;
    }
    public void GrandpaIsFuckingDead()
    {
        animator.SetTrigger("deadNoPee");
        dead = true;
        currPlay = "still no pee";
        backgroundMusicSource.enabled = false;
        return;
    }
    public void GrandpaIsFuckingDeadAndPissInfused()
    {
        animator.SetTrigger("deadAndPissInfused");
        grandpaInfusedWithPiss = true;
        dead = true;
        currPlay = "still pee";
        backgroundMusicSource.enabled = false;
        return;
    }
    #endregion

    
}
