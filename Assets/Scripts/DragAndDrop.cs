using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Transform _transform;
    private Vector3 _dragOffset;
    private Camera _camera;
    private Vector3 _resetPos;
    [SerializeField] private GameObject _dropSlot;
    [SerializeField] private float _speed = 100;

    public GameObject ivBag;
    
    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _camera = Camera.main;
        _resetPos = this.transform.localPosition;
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
            this.transform.localPosition = new Vector3(_dropSlot.transform.localPosition.x, _dropSlot.transform.localPosition.y);
            ivBag.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
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
