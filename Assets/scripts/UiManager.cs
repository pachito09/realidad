using UnityEngine;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject editMenuPanel;

    // private GameObject currObject = null;
    private GameObject selectedObj;
    public GameObject Selected { get => selectedObj; set => selectedObj = value; }

    private void OnEnable()
    {
        GameManager.OnMainMenu += OnMainMenuPanel;
        GameManager.OnInventoryMenu += OnInventoryPanel;
        GameManager.OnEditMenu += OnEditMenuPanel;
        GameManager.OnTakeScreenshot += OnTakeScreenshot;
    }
    private void OnDisable()
    {
        GameManager.OnMainMenu -= OnMainMenuPanel;
        GameManager.OnInventoryMenu -= OnInventoryPanel;
        GameManager.OnEditMenu -= OnEditMenuPanel;
        GameManager.OnTakeScreenshot -= OnTakeScreenshot;
    }

    public void OnMainMenuPanel()
    {
        mainMenuPanel.SetActive(true);
        inventoryPanel.SetActive(false);
        editMenuPanel.SetActive(false);
    }
    public void OnInventoryPanel()
    {
        mainMenuPanel.SetActive(false);
        inventoryPanel.SetActive(true);
        editMenuPanel.SetActive(false);
    }
    public void OnEditMenuPanel()
    {
        mainMenuPanel.SetActive(false);
        inventoryPanel.SetActive(false);
        editMenuPanel.SetActive(true);
    }
    public void OnTakeScreenshot()
    {
        mainMenuPanel.SetActive(false);
        inventoryPanel.SetActive(false);
        editMenuPanel.SetActive(false);
    }
}
