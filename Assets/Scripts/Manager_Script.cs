using UnityEngine;
public class NewMonoBehaviourScript : MonoBehaviour
{
    public enum GameState
    {
        PLAY, PAUSE
    }

    public GameState state;

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
            }
        }
        else if (state == GameState.PAUSE)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                state = GameState.PLAY;
            }
        }
    }
}
