using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EKGManager : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip flatlineSFX;
    
    private AudioSource audioSource;
    private GrandpaManager grandpaManager;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponentInChildren<AudioSource>();
        animator = GetComponent<Animator>();
        grandpaManager = GameObject.FindWithTag("Grandpa").GetComponent<GrandpaManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grandpaManager.grandpaHealth == 2)
            animator.Play("Low");
        else if (grandpaManager.grandpaHealth == 1)
            animator.Play("Critical");
        else if (grandpaManager.grandpaHealth == 0)
            animator.Play("Chat is this real");
            
        if (grandpaManager.dead && !audioSource.clip.Equals(flatlineSFX))
        {
            audioSource.clip = flatlineSFX;
            audioSource.Play();
        }
    }
}
