using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject InventoryMenu;
    [SerializeField] private GameObject EditPanel;

    private void OnEnable()
    {
        GameManager.MainMenu += OnMainMenuPanel;
        GameManager.InventoryMenu += OnInventoryPanel;
        GameManager.EditMenu += OnEditPanel;
    }
    private void OnDisable()
    {
        GameManager.MainMenu -= OnMainMenuPanel;
        GameManager.InventoryMenu -= OnInventoryPanel;
        GameManager.EditMenu -= OnEditPanel;

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
