using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
using JetBrains.Annotations;

public class PlayerCharacterController : ThirdPersonController
{
    public GameManager manager;

    private void OnPause(InputValue value)
    {
        if (value.isPressed)
        {
            manager.GetComponent<GameManager>().Pausing();
        }
    }
}
