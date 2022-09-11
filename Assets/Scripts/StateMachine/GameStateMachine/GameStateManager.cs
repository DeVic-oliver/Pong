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
    
    private GameStateBase _currentState;
    public GameManager _gameManager;


    private void Awake()
    {
        SetInitialState();
    }

    // Start is called before the first frame update
    void Start()
    {
        //InitComponents();
    }

    private void InitComponents()
    {
        _gameManager = GetComponent<GameManager>();
    }

    private void SetInitialState()
    {
        _currentState = StartState;
        _currentState.OnStateEnter(this);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState(this);
    }
    public void SwitchState(GameStateBase newState)
    {
        _currentState = newState;
        _currentState.OnStateEnter(this);
    }
}
