using System;
using System.IO;
using UnityEngine;
using System.Collections;
using UnityEngine.XR.ARFoundation;
public enum AppStates { DeFault, InMainMenu, InInventoryMenu, InEditMenu }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static event Action OnMainMenu;
    public static event Action OnInventoryMenu;
    public static event Action OnEditMenu;
    public static event Action OnTakeScreenshot;
    public static event Action OnEndTakeScreenshot;

    public ARPlaneManager planeManager;

    public GameObject currObject = null;
    public GameObject selectedObject;

    public AppStates appStates;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        MainMenu();
    }

    public void CreateObject(GameObject obj)
    {
        if (currObject != null)
        {
            DestroyObject(currObject);
        }
        currObject = Instantiate(obj, Vector3.zero, Quaternion.identity);
    }
    public void DestroyObject()
    {
        Destroy(currObject);
    }
    public void DestroyObject(GameObject obj)
    {
        Destroy(obj);
    }
    public void SelecObjToPlace(GameObject prefab)
    {
        currObject = prefab;
    }
    public GameObject GetSelectedPrefab()
    {
        return currObject;
    }
    public void MainMenu()
    {
        OnMainMenu?.Invoke();
        appStates = AppStates.InMainMenu;
        Debug.Log($"Se llamo al Main Menu");
    }
    public void InventoryMenu()
    {
        OnInventoryMenu?.Invoke();
        appStates = AppStates.InInventoryMenu;
        Debug.Log($"Se llamo al Inventory Menu");
    }
    public void EditMenu()
    {
        OnEditMenu?.Invoke();
        appStates = AppStates.InEditMenu;
        Debug.Log($"Se llamo al Edit Menu");
    }
    public void TakeScreenshot()
    {
        OnTakeScreenshot?.Invoke();
        HidePlanes();
    }
    public void EndTakeScreenshot()
    {
        OnEndTakeScreenshot?.Invoke();
        MainMenu();
        ShowPlanes();
    }
    public void HidePlanes()
    {
        var planes = planeManager.trackables;
        foreach (var plane in planes)
        {
            plane.gameObject.SetActive(false);
        }
    }
    public void ShowPlanes()
    {
        var planes = planeManager.trackables;
        foreach (var plane in planes)
        {
            plane.gameObject.SetActive(true);
        }

    }
    public void Exit()
    {
        Application.Quit();
    }
    public void ShareScreenshot()
    {
        StartCoroutine(Screenshot());
    }
    private IEnumerator Screenshot()
    {
        TakeScreenshot();
        yield return new WaitForEndOfFrame();


        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        Destroy(ss);

        new NativeShare().AddFile(filePath)
            .SetSubject("Subject goes here").SetText("Hola esto es una prueba fusunga")
            .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
            .Share();

        EndTakeScreenshot();
    }
}