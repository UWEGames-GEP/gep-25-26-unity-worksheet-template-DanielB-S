using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
using JetBrains.Annotations;

public class PlayerCharacterController : ThirdPersonController
{
    public GameManager manager;
    //public Inventory inventory;

    private void OnPause(InputValue value)
    {
        if (value.isPressed)
        {
            manager.GetComponent<GameManager>().Pausing();
        }
    }

    private void OnRemoveItem(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("Remove Item");
            GetComponent<Inventory>().RemoveItemFromInventory();
        }
    }
}
