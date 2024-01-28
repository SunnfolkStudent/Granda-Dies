using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{


    public GameObject gameObject;
    private Transform _transform;
    private Vector3 _dragOffset;
    private Camera _camera;
    private Vector3 _resetPos;
    [SerializeField] private GameObject _dropSlot;
    [SerializeField] private float _speed = 100;
    private SpriteRenderer ivOpacity;
    private SpriteRenderer peeBagOpacity;
    
    private float opacityscale;
    private float endTimer;

    private bool ivSwitch;

    public GameObject ivPiss;
    public GameObject awakeGranpa;
    
    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _camera = Camera.main;
        _resetPos = this.transform.localPosition;
    }

    private void Start()
    {
        ivOpacity = ivPiss.GetComponent<SpriteRenderer>();
        peeBagOpacity = gameObject.GetComponent<SpriteRenderer>();
        opacityscale = 0;
        ivOpacity.color = new Color(1f, 1f, 1f, 0f);
    }

    private void Update()
    {
        if (ivSwitch == true)
        {
          opacityscale += 0.5f * Time.deltaTime;
          Debug.Log("Begin filling with piss");
        }
        ivOpacity.color = new Color(1f, 1f, 1f, opacityscale);
        
        
        if (opacityscale > 1)
        {
            awakeGranpa.SetActive(true);
            ivSwitch = false;
            endTimer += 0.5f * Time.deltaTime;
        }

        if (endTimer > 1)
        {
           gameObject.SetActive(false);
            Debug.Log("unloading");
            PlayerController.canMove = true;
            var temp = GameObject.FindWithTag("Grandpa");
            
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        _dragOffset = transform.position - GetMousePos();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        if (Mathf.Abs(this.transform.localPosition.x - _dropSlot.transform.localPosition.x) <= 1f 
            && Mathf.Abs(this.transform.localPosition.y - _dropSlot.transform.localPosition.y) <= 1f)
        {
            Debug.Log("Correct area");
            peeBagOpacity.color = new Color(1f, 1f, 1f, 0);
            ivSwitch = true;
        }
        else
        {
            this.transform.localPosition = new Vector3(_resetPos.x, _resetPos.y, _resetPos.z);
        }
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        _transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
    }

    Vector3 GetMousePos()
    {
        var mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
