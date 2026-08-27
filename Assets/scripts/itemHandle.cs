using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemHandle : MonoBehaviour
{
    public ItemScritable scripTableObject;

    [SerializeField] private Image previewItemImage;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }
    public void Start()
    {
        button.onClick.AddListener(() => CreateObj());
    }
    public void LoadData()
    {
        previewItemImage.sprite = scripTableObject.itemIcono;
        itemDescriptionText.text = scripTableObject.itemDescripcion;
        itemNameText.text = scripTableObject.itemName;
    }
    public void CreateObj()
    {
        //GameManager.Instance.CreateObjects(ItemScritable.modelo);
    }
}