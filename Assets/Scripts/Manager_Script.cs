using System.Collections;
using UnityEngine;
public class GameManager : MonoBehaviour
{

    public GameState state;
    bool hasChangedState;
    public GameObject InventoryUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = GameState.PLAY;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pausing()
    {
        //Switch Statement for changing state when esc is pressed
        switch (state)
        {
            case GameState.PLAY:
                state = GameState.PAUSE;
                hasChangedState = true;
                break;

            case GameState.PAUSE:
                state = GameState.PLAY;
                hasChangedState = true;
                break;
        }
    }
    private void LateUpdate()
    {
        //Switch Statement to freeze or unfreeze the game when esc is pressed
        switch (state)
        {
            case GameState.PLAY:
                Time.timeScale = 1.0f; 
                InventoryUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked; break;

            case GameState.PAUSE:
                Time.timeScale = 0.0f; 
                InventoryUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None; break;
        }

    }
}

public enum GameState
{
    PLAY, PAUSE
}