using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : PauseGameHandler, IGameStateBase, IMouseBehaviour, IRestartGame
{
    private GameStateManager _gameStateManager;
    public void OnStateEnter(GameStateManager gameState)
    {
        _gameStateManager = gameState;
        SetGameObjectsActive();
        ChangeMouseCursorBehaviour();
        ChangePauseTimeScale();
    }
    private void SetGameObjectsActive()
    {
        _gameStateManager.PauseMenu.SetActive(true);
    }
    public void ChangeMouseCursorBehaviour()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    protected override void ChangePauseTimeScale()
    {
        Time.timeScale = 0;
    }

    public void UpdateState(GameStateManager gameState)
    {
        ChangeGameStateBetweenPauseAndPlay(gameState);
        CheckIfShouldResumeGame();
        CheckIfShouldRestartGame();
       
    }
    private void CheckIfShouldResumeGame()
    {
        if (PauseGameHandler.ShouldResumeGame)
        {
            PauseGameHandler.IsGamePaused = false;
            PauseGameHandler.ShouldResumeGame = false;
            _gameStateManager.SwitchState(_gameStateManager.PlayState);
        }
    }
    public void CheckIfShouldRestartGame()
    {
        if (GameStateManager.ShouldRestartGame)
        {
            PauseGameHandler.IsGamePaused = false;
            _gameStateManager.SwitchState(_gameStateManager.RestartState);
        }
    }
}
