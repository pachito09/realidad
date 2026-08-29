using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject InventoryMenu;
    [SerializeField] private GameObject EditPanel;

    private void OnEnable()
    {
        GameManager.OnMainMenu += OnMainMenuPanel;
        GameManager.OnInventoryMenu += OnInventoryPanel;
        GameManager.OnEditMenu += OnEditPanel;
        GameManager.OnEditMenu += OnTakeScreenShot;
    }
    private void OnDisable()
    {
        GameManager.OnMainMenu -= OnMainMenuPanel;
        GameManager.OnInventoryMenu -= OnInventoryPanel;
        GameManager.OnEditMenu -= OnEditPanel;
        GameManager.OnEditMenu -= OnTakeScreenShot;

    }
    public void OnMainMenuPanel()
    {
        mainMenu.SetActive(true);
        InventoryMenu.SetActive(false);
        EditPanel.SetActive(false);
    }
    public void OnInventoryPanel()
    {
        InventoryMenu.SetActive(true);
        mainMenu.SetActive(false);
        EditPanel.SetActive(false);
    }
    public void OnEditPanel()
    {
        EditPanel.SetActive(true);
        mainMenu.SetActive(false);
        InventoryMenu.SetActive(false);
    }
    public void OnTakeScreenShot()
    {
        EditPanel.SetActive(false);
        mainMenu.SetActive(false);
        InventoryMenu.SetActive(false);
    }
}
