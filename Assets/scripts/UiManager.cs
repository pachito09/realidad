using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject InventoryMenu;
    [SerializeField] private GameObject EditPanel;

    private void OnEnable()
    {
        GameManager.OnMainMenu += OnMainMenuPanel;
        GameManager.OnInventory += OnInventoryPanel;
        GameManager.OnEditMenu += OnEditPanel;
    }
    private void OnDisable()
    {
        GameManager.OnMainMenu -= OnMainMenuPanel;
        GameManager.OnInventory -= OnInventoryPanel;
        GameManager.OnEditMenu -= OnEditPanel;

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
}
