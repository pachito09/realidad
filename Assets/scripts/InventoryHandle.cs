using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;

public class InventoryHandle : MonoBehaviour
{
    public List<ItemScritable> itemsList = new List<ItemScritable>();

    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform spawnCard;

    void Start()
    {
        LoadCards();
    }

    public void LoadCards()
    {
        if (itemsList.Count != 0)
        {
            GameObject cardTemp = null;
            foreach (ItemScritable scriptable in itemsList)
            {
                cardTemp = Instantiate(cardPrefab, spawnCard);
                cardTemp.GetComponent<ItemHandle>().scripTableObject = scriptable;
                cardTemp.GetComponent<ItemHandle>().LoadData();
            }
        }
        else
        {
            Debug.LogWarning("El listado de items está vacío");
        }
    }
}
