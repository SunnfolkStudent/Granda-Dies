using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GrandpaManager : MonoBehaviour
{

    [SerializeField] private AudioSource backgroundMusicSource;
    
    private Animator animator;
    private String currPlay;
    
    [Header("Death Modifiers")]
    public bool grandpaInfusedWithPiss, dead;
    
    [Header("Health")]
    public int grandpaHealth;

    private CinemachineVirtualCamera camera;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currPlay = "breathe no pee";
        grandpaHealth = 3;
        camera = GameObject.FindWithTag("MainCamera").GetComponentInChildren<CinemachineVirtualCamera>();
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

        if (grandpaHealth == 0)
        {
            StartCoroutine(Timer());
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

    IEnumerator Timer()
    {
        camera.Follow = transform;
        
        yield return new WaitForSeconds(10);
        Debug.Log("Waited" + Time.time);
    }
}
