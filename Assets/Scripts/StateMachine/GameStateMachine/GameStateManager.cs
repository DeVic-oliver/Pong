using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public StartState StartState = new StartState();
    public PlayState PlayState = new PlayState();
    public PauseState PauseState = new PauseState();
    public RestartState RestartState = new RestartState();
    public GameOverState GameOverState = new GameOverState();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchState(GameStateBase state)
    {

    }
}
