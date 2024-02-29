using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    public GameObject ivPiss;
    public GameObject grampaAwake;
    public float ivPissTransparency = 0f;
    public float endingTimer = 0f;

    public static bool droppedPiss;
    
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (droppedPiss)
        {
            Debug.Log("droppedPiss");

            _canvasGroup.alpha = 0f;
            _canvasGroup.interactable = false;

            ivPissTransparency += 0.25f * Time.deltaTime;
            
        }

        if (ivPissTransparency >= 1f)
        {
            droppedPiss = false;
            grampaAwake.SetActive(true);

            endingTimer += 0.25f * Time.deltaTime;
        }

        if (endingTimer >= 1)
        {
            SceneManager.UnloadSceneAsync("Piss Minigame");
            Debug.Log("unloading");
            PlayerController.canMove = true;
            var temp = GameObject.FindWithTag("Grandpa");
            GrandpaDespairCutsceneManager.playCutscene = true;
        }
        
        ivPiss.GetComponent<SpriteRenderer>().color = new Color(1,1,1,ivPissTransparency);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("On Pointer Down");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        _canvasGroup.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        _rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    
}
