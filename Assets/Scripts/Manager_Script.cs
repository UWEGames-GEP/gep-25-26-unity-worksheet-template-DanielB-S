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
    }

    private void LateUpdate()
    {
        if (hasChangedState)
        {
            hasChangedState = false;

            if (state == GameState.PLAY)
            {
                Time.timeScale = 1.0f;
            }
            else if (state == GameState.PAUSE)
            {
                Time.timeScale = 0.0f;
            }
        }
    }
}
