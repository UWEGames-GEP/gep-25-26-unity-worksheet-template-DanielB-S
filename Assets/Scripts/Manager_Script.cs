using System.Collections;
using UnityEngine;
public class NewMonoBehaviourScript : MonoBehaviour
{
    public enum GameState
    {
        PLAY, PAUSE
    }

    public GameState state;
    bool hasChangedState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = GameState.PLAY;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == GameState.PLAY)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                state = GameState.PAUSE;
                hasChangedState = true;
            }
        }
        else if (state == GameState.PAUSE)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                state = GameState.PLAY;
                hasChangedState = true;
            }
        }

        /*switch (state)
        {
            case GameState.PLAY:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    state = GameState.PAUSE;
                    hasChangedState = true;
                }
                break;
                
            case GameState.PAUSE:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    state = GameState.PLAY;
                    hasChangedState = true;
                }
                break;
        }*/
    }

    private void LateUpdate()
    {
        switch (state)
        {
            case GameState.PLAY:
                Time.timeScale = 1.0f; break;

            case GameState.PAUSE:
                Time.timeScale = 0.0f; break;
        }

    }
}
