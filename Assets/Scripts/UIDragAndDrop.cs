using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIDragAndDrop : MonoBehaviour, IPointerDownHandler,IBeginDragHandler,IEndDragHandler, IDragHandler
{
    private RectTransform _transform;
    private CanvasGroup _canvasGroup;
    //private Vector3 _dragOffset;
    //private Camera _camera;
    //private Vector3 _resetPos;
    //[SerializeField] private GameObject _dropSlot;
    //[SerializeField] private float _speed = 100;
    [SerializeField] private Canvas _canvas;
    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        //_camera = Camera.main;
        //_resetPos = this.transform.localPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        /*_dragOffset = transform.position - GetMousePos();*/
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        _canvasGroup.alpha = .6f;
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
        /*if (Mathf.Abs(this.transform.localPosition.x - _dropSlot.transform.localPosition.x) <= 0.5f
            && Mathf.Abs(this.transform.localPosition.y - _dropSlot.transform.localPosition.y) <= 0.5f)
        {
            Debug.Log("Correct area");
            //this.transform.localPosition = new Vector3(_dropSlot.transform.localPosition.x, _dropSlot.transform.localPosition.y);
        }
        else
        {
            this.transform.localPosition = new Vector3(_resetPos.x, _resetPos.y, _resetPos.z);
        }*/

    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        _transform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    /*Vector3 GetMousePos()
    {
        var mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }*/
}
