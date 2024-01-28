using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    private CinemachineVirtualCamera camera;
    private GameObject parentCutscene;
    
    [SerializeField] private AudioSource doorAudio;
    
    public bool timerActive;
    
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindWithTag("MainCamera").GetComponentInChildren<CinemachineVirtualCamera>();
        parentCutscene = GameObject.FindWithTag("Parents");
        parentCutscene.SetActive(false);
    }

    // Update is called once per frame
    public void StartDeathTimer()
    {
        if (!timerActive)
            StartCoroutine(Timer());
        
        timerActive = true;
    }
    
    IEnumerator Timer()
    {
        PlayerController.canMove = false;
        camera.Follow = transform;

        yield return new WaitForSeconds(9f);
        doorAudio.Play();
        
        yield return new WaitForSeconds(1f);
        parentCutscene.SetActive(true);
        
        camera.Follow = parentCutscene.transform;
        camera.m_Lens.OrthographicSize = 0.95f;
        
        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene("Credits Scene");
    }
}
