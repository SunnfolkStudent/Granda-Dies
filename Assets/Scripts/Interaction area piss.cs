using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Interactionareapiss : MonoBehaviour
{
    public InputActionReference interract;
    
    [Header("Sprite")]
    public Sprite normalSprite;
    public Sprite outlineSprite;
    public SpriteRenderer spriteRenderer;

    [Header("Minigame")] 
    public GameObject gameObject;

    [Header("Change Items in Scene")] 
    public GameObject[] objectsToDelete;
    public GameObject objectChangeSprite;
    public Sprite spriteToUse;
    
    private bool entered;
    private bool interacted;
    private GrandpaManager grandpaManager;
    
    void Start()
    {
        entered = false;
        grandpaManager = GameObject.FindWithTag("Grandpa").GetComponent<GrandpaManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            entered = true;
            Debug.Log("Entered Interaction Area");
            spriteRenderer.sprite = outlineSprite;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        entered = false;
        spriteRenderer.sprite = normalSprite;
    }

    void Update()
    {
        if (entered && PlayerController.interaction)
        {
            OpenPopUpScreen();
        }

        if (interacted)
        {
            Destroy(gameObject);
            
            foreach (var obj in objectsToDelete)
                Destroy(obj);
           
            
            objectChangeSprite.GetComponent<SpriteRenderer>().sprite = spriteToUse; 
            grandpaManager.grandpaHealth--;
            grandpaManager.InfuseWithPiss();
        }
    }

    void OpenPopUpScreen()
    {
        gameObject.SetActive(true);
        PlayerController.canMove = false;
        interacted = true;
    }
}
