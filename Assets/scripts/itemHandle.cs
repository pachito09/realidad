using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class itemHandle : MonoBehaviour
{
    public ItemScriptable scriptableObj;
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
        previewItemImage.sprite = scriptableObj.itemPreview;
        itemNameText.text = scriptableObj.itemName;
        itemDescriptionText.text = scriptableObj.itemDescription;
    }

    private void CreateObject()
    {
        GameManager.Instance.CreateObject(scriptableObj.itemObj);
    }
    void SelectItem()
    {
        GameManager.Instance.selectedObject = scriptableObj.itemObj;
    }
}