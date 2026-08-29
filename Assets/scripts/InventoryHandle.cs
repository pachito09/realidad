using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class inventoryHandle : MonoBehaviour
{
    [SerializeField] private List<ItemScritable> itemsList = new List<ItemScritable>();
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform spawnCards;

    private void Start()
    {
        LoadCards();
    }

    public void LoadCards()
    {
        if (itemsList.Count != 0)
        {
            GameObject cardTemp = null;
            foreach (ItemScritable scripTable in itemsList)
            {
                cardTemp = Instantiate(cardPrefab, spawnCards);
                cardTemp.GetComponent<itemHandle>().scriptableObj = scripTable;
                cardTemp.GetComponent<itemHandle>().LoadData();
            }
        }
        else
        {
            Debug.LogWarning("El listado de items esta vacio");
        }
    }
}
