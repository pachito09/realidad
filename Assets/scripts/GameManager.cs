using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GameObject currObject = null;

    public static event Action MainMenu;
    public static event Action InventoryMenu;
    public static event Action EditMenu;

    private void Start()
    {
        OnMainMenu();
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        else
        {
            Instance = this;
        }
    }

    public void OnMainMenu()
    {
        MainMenu?.Invoke();
        Debug.Log(" llama MainMenu");
    }
    public void OnInventory()
    {
        MainMenu?.Invoke();
        Debug.Log(" llama InventoryMenu");
    }
    public void OnEditMenu()
    {
        MainMenu?.Invoke();
        Debug.Log(" llama EditMenu");
    }
    public void CreateObjects(GameObject obj)
    {
        if (currObject != null)
        {
            DestroyObject(currObject);
        }
        currObject = Instantiate(obj, Vector3.zero, Quaternion.identity);
    }

    public void DestroyObject(GameObject obj)
    {
        Destroy(obj);
    }
}
