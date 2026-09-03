using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class itemHandle : MonoBehaviour
{
    public ItemScritable scriptableObj;
    [SerializeField] private Image previewItemImage;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;
    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();
    }
    void Start()
    {
        button.onClick.AddListener(() => SelectItem());
        //button.onClick.AddListener(() => GameManager.Instance.EditMenu());
    }

    public void LoadData()
    {
        previewItemImage.sprite = scriptableObj.itemIcono;
        itemNameText.text = scriptableObj.itemName;
        itemDescriptionText.text = scriptableObj.itemDescripcion;
    }

    private void CreateObject()
    {
        GameManager.Instance.CreateObject(scriptableObj.modelo);
    }
    void SelectItem()
    {
        GameManager.Instance.selectedObject = scriptableObj.modelo;
    }
}