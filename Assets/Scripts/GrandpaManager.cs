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
    public static int grandpaHealth;

    [Header("Audio")]
    [SerializeField] private AudioClip deathClip;
    [SerializeField] private AudioClip ambienceClip;
    
    private DeathManager deathManager;
    
    #region -----Cached Strings-----
    
    private static readonly int AliveAndPissInfused = Animator.StringToHash("aliveAndPissInfused");
    private static readonly int DeadNoPee = Animator.StringToHash("deadNoPee");
    private static readonly int DeadAndPissInfused = Animator.StringToHash("deadAndPissInfused");

    #endregion

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
        if (dead) { return; }
        
        if (grandpaHealth <= 0 && !grandpaInfusedWithPiss)
        {
            dead = true;
            GrandpaIsFuckingDead();
        }
        else if (grandpaHealth <= 0 && grandpaInfusedWithPiss)
        {
            dead = true;
            GrandpaIsFuckingDeadAndPissInfused();
        }

        if (grandpaHealth <= 0 && !deathManager.timerActive)
        {
            deathManager.StartDeathTimer();
            audioSource.Stop();
            audioSource.volume = 1f;
            audioSource.PlayOneShot(deathClip);
            audioSource.loop = false;
            grandpaHealth--;
        }
    }

    #region -----Animations-----
    public void InfuseWithPiss()
    {
        animator.SetTrigger(AliveAndPissInfused);
        grandpaInfusedWithPiss = true;
        currPlay = "breathe pee";
        return;
    }
    public void GrandpaIsFuckingDead()
    {
        animator.SetTrigger(DeadNoPee);
        KillGrandpa();
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().AnimateHappy();
        return;
    }
    public void GrandpaIsFuckingDeadAndPissInfused()
    {
        animator.SetTrigger(DeadAndPissInfused);
        grandpaInfusedWithPiss = true;
        KillGrandpa();
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().AnimateHappy();
        return;
    }
    #endregion

    private void KillGrandpa()
    {
        dead = true;
        currPlay = "still pee";
        backgroundMusicSource.enabled = false;
    }
}
