using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Build.Content;

public class Inventory : MonoBehaviour
{
    public List<string> items = new List<string>();

    public GameManager manager;

    public void AddItemToInventory(string itemName)
    {
        items.Add(itemName);
    }

    public void RemoveItemFromInventory(string itemName)
    {
        items.Remove(itemName);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AddItemToInventory("Generic Item");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            RemoveItemFromInventory("Generic Item");
        }
    }
}
