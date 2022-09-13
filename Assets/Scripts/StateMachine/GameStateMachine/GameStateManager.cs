using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static bool ShouldRestartGame;

    #region Concrete Game States
    public StartState StartState = new StartState();
    public PlayState PlayState = new PlayState();
    public PauseState PauseState = new PauseState();
    public RestartState RestartState = new RestartState();
    public GameOverState GameOverState = new GameOverState();
    #endregion;

    [HeaderAttribute("GameObjects to manage")]
    #region GameObjects
    public GameManager _gameManager;
    public GameObject MainMenu;
    public GameObject PauseMenu;
    public GameObject GameOverMenu;
    #endregion;

    private IGameStateBase _currentState;


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
    public void SwitchState(IGameStateBase newState)
    {
        _currentState = newState;
        _currentState.OnStateEnter(this);
    }
}
