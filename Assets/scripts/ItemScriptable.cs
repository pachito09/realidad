using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemScriptable", menuName = "Inventario/Item")]
public class ItemScriptable : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemPreview;
    public GameObject itemObj;
}
