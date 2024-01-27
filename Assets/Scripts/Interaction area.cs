using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactionarea : MonoBehaviour
{
    public InputActionReference interract;
    public GameObject popUpScreen;
    public static bool closePopUp;

    private bool entered;
    
    void Start()
    {
        entered = false;
        popUpScreen.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            entered = true;
            Debug.Log("Entered Interaction Area");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        entered = false;
    }

    void Update()
    {
        if (entered && PlayerController.interaction)
        {
            OpenPopUpScreen();
        }

        if (closePopUp)
        {
            ClosePopUpScreen();
            closePopUp = false;
        }
        
    }

    private void ClosePopUpScreen()
    {
        popUpScreen.SetActive(false);
        PlayerController.canMove = false;
    }

    void OpenPopUpScreen()
    {
        popUpScreen.SetActive(true);
        PlayerController.canMove = true;
    }
}
