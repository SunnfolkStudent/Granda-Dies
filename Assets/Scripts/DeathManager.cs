using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    private CinemachineVirtualCamera camera;
    private GameObject parentCutscene;
    
    public bool timerActive;
    
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindWithTag("MainCamera").GetComponentInChildren<CinemachineVirtualCamera>();
        parentCutscene = GameObject.FindWithTag("Parents");
        parentCutscene.SetActive(false);
    }

    // Update is called once per frame
    public void startDeathTimer()
    {
        if (!timerActive)
            StartCoroutine(Timer());
        
        timerActive = true;
    }
    
    IEnumerator Timer()
    {
        camera.Follow = transform;
        
        yield return new WaitForSeconds(10);
        parentCutscene.SetActive(true);
        
        camera.Follow = parentCutscene.transform;
        camera.m_Lens.OrthographicSize = 0.95f;
    }
}
