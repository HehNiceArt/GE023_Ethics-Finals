using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Interactables : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;
    [SerializeField] string openName;
    [SerializeField] string closeName;
    private Color defaultColor = Color.white;
    [Header("References")]
    [SerializeField] GameObject expandItem;
    [SerializeField] bool isExpand = false;
    [SerializeField] Button close;

    [Header("Colors")]
    public Color hoverColor = new Color(0.9f, 0.9f, 1f);
    public Color clickColor = new Color(0.7f, 0.7f, 1f);

    private void Awake()
    {
        image = GetComponent<Image>();
        image.color = defaultColor;
    }
    private void Start()
    {
        expandItem.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = hoverColor;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = defaultColor;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        image.color = clickColor;
        AudioManage.Instance.PlaySFX(openName);
        isExpand = true;
        expandItem.SetActive(true);
    }
    private void Update()
    {
        InputKeys();
    }

    void InputKeys()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && isExpand)
        {
            AudioManage.Instance.PlaySFX(closeName);
            expandItem.SetActive(false);
        }
    }
    public void OnCancel()
    {
        isExpand = false;
        AudioManage.Instance.PlaySFX(closeName);
        expandItem.SetActive(false);
    }
}
