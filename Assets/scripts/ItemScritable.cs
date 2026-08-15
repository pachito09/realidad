using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemScriptable", menuName = "Inventario/Item")]
public class ItemScritable : ScriptableObject
{
    public string itemName;
    public string itemDescripcion;
    public Sprite itemIcono;
    public GameObject modelo;
}
