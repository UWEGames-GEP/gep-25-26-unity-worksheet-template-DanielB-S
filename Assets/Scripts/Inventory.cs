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

    /*public void RemoveItemFromInventory(Collectable item)
    {
        items.Remove(item);
    }*/

    public void RemoveItemFromInventory(Collectable item)
    {
       Vector3 currentPosition = transform.position;
       Vector3 forward = transform.forward;

       Vector3 newPosition = currentPosition + forward;
       newPosition += new Vector3(0, 1, 0);

       Quaternion currentRotation = transform.rotation;
       Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, 100);

       GameObject newItem = Instantiate(item.gameObject, newPosition, newRotation, worldItemsTransform);
       newItem.SetActive(true);

       items.Remove(item);
       Destroy(item.gameObject);  
    }

    public void RemoveItemFromInventory()
    {
        if (manager.state == GameState.PLAY && items.Count > 0)
        {
            Collectable item = items[0];
            RemoveItemFromInventory(item);
        }
    }


    /*public void RemoveItemFromInventory()
    {
        if (manager.state == GameState.PLAY && items.Count > 0)
        {
            Collectable item = items[0];

            Vector3 currentPosition = transform.position;
            Vector3 forward = transform.forward;

            Vector3 newPosition = currentPosition + forward;
            newPosition += new Vector3(0, 1, 0);

            Quaternion currentRotation = transform.rotation;
            Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, 100);

            GameObject newItem = Instantiate(item.gameObject, newPosition, newRotation, worldItemsTransform);
            newItem.SetActive(true);

            items.Remove(item);
            Destroy(item.gameObject);
        }
    }*/

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
