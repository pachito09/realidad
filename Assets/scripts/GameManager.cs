using UnityEngine;
using System;

public enum AppStates { Default, InMainMenu, InInventoryMenu, InEditMenu }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GameObject currObject = null;

    public AppStates appStay = AppStates.Default;

    public static event Action MainMenu;
    public static event Action InventoryMenu;
    public static event Action EditMenu;

    private void Awake()
    {
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

    private void Start()
    {
        OnMainMenu();
    }

    public void OnMainMenu()
    {
        MainMenu?.Invoke();
        appStay = AppStates.InMainMenu;
        Debug.Log(" llama MainMenu");
    }
    public void OnInventory()
    {
        InventoryMenu?.Invoke();
        appStay = AppStates.InInventoryMenu;
        Debug.Log(" llama InventoryMenu");
    }
    public void OnEditMenu()
    {
        EditMenu?.Invoke();
        appStay = AppStates.InEditMenu;
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
