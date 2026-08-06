using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Cosita", menuName = "Inventario/Item")]
public class cosita : ScriptableObject
{
    public string itemName;   
    public string itemDescripcion;
    public Sprite itemIcono;
    public GameObject modelo;
}
