using System;
using System.Collections;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class GrandpaDespairCutsceneManager : MonoBehaviour
{

    private AudioSource audioSource;
    private CinemachineVirtualCamera vCam;
    private PlayerController player;
    public static bool playCutscene;
    
    [SerializeField] private AudioClip grandpaAgony;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        vCam = GameObject.FindWithTag("MainCamera").GetComponentInChildren<CinemachineVirtualCamera>();
        //this.GameObject().SetActive(false);
    }

    private void Update()
    {
        if (playCutscene)
        {
            StartCoroutine(AgonizeGrandpa());
            playCutscene = false;
        }
        return;
    }
    
    
    IEnumerator AgonizeGrandpa()
    {
        //this.GameObject().SetActive(true);
        vCam.Follow = transform;
        audioSource.PlayOneShot(grandpaAgony);
        yield return new WaitForSeconds(2f);
        
        vCam.Follow = GameObject.FindWithTag("Player").transform;
        PlayerController.canMove = true;
        //this.GameObject().SetActive(false);
    }
}
