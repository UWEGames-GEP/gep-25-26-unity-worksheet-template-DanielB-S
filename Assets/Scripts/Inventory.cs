using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Build.Content;

public class Inventory : MonoBehaviour
{
    //public class ItemObject {}

    public List<ItemObject> items = new List<ItemObject>();

    public GameManager manager;

    public void AddItemToInventory(ItemObject item)
    {
        items.Add(item);
    }

    public void RemoveItemFromInventory(ItemObject item)
    {
        items.Remove(item);
    }

    public void RemoveItemFromInventory()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        ItemObject collisionItem = hit.gameObject.GetComponent<ItemObject>();

        if (collisionItem != null)
        {
            items.Add(collisionItem);
            
            collisionItem.gameObject.SetActive(false);
        }
    }

}
