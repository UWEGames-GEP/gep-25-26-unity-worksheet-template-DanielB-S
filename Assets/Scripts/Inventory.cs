using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine.Android;

public class Inventory : MonoBehaviour
{
    //public class ItemObject {}

    public List<Collectable> items = new List<Collectable>();

    public GameManager manager;
    Transform worldItemsTransform;

    public void AddItemToInventory(Collectable item)
    {
        items.Add(item);
    }

    public void RemoveItemFromInventory(Collectable item)
    {
        items.Remove(item);
    }

    public void RemoveItemFromInventory()
    {
        if (manager.state == GameState.PLAY && items.Count > 0)
        {

        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = FindAnyObjectByType<GameManager>();

        Transform worldItemsTransform = GameObject.Find("WorldItems").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Collectable collisionItem = hit.gameObject.GetComponent<Collectable>();

        if (collisionItem != null)
        {
            items.Add(collisionItem);
            
            collisionItem.gameObject.SetActive(false);
        }
    }

}
