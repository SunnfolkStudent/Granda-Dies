using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Interactionarea : MonoBehaviour
{
    public InputActionReference interract;
    public Sprite normalSprite;
    public Sprite outlineSprite;
    public SpriteRenderer spriteRenderer;
    public string minigame;

    private bool entered;
    private bool interacted;
    
    void Start()
    {
        entered = false;
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
        }
    }

    void OpenPopUpScreen()
    {
        SceneManager.LoadScene(minigame, LoadSceneMode.Additive);
        PlayerController.canMove = false;
        interacted = true;
    }
}
