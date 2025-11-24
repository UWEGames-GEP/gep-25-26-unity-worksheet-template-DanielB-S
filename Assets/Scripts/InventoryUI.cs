using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Search;

public class InventoryUI
{
    public Inventory inventory;
    public List<GameObject> inventoryUIButtons = new List<GameObject>();

    private void OnEnable()
    {
        RefreshInventory();
    }

    void RefreshInventory()
    {
        Debug.Log("Refresh Inventory UI");

        foreach (GameObject uiButton in inventoryUIButtons)
        {
            uiButton.SetActive(false);
        }

        for (int i = 0; i < inventory.items.Count; i++)
        {
            if (i <  inventoryUIButtons.Count)
            {
                InventoryUIButton uiButton = inventoryUIButtons[i].GetComponent<InventoryUIButton>();
                Collectable item = inventory.items[i];

                uiButton.gameObject.SetActive(true);
                uiButton.SetButton(item);
            }
        }
    }

    /*public void RemoveItemFromInventory(int i)
    {
        if (i < items.Count)
        {
            RemoveItemFromInventory(items[i]);
        }
    }

    public void OnInventoryUIButton(int i)
    {
        inventory.RemoveItemFromInventory(i);
        RefreshInventory();
    }*/
}
