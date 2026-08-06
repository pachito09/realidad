using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class itemHandle : MonoBehaviour
{
    [SerializeField] private cosita scripTableObject;
 
    [SerializeField] private Image previewItemImage;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;

    private void Start()
    {
        previewItemImage.sprite = scripTableObject.itemIcono;
        itemDescriptionText.text = scripTableObject.itemDescripcion;
        itemNameText.text = scripTableObject.itemName;
    }
}