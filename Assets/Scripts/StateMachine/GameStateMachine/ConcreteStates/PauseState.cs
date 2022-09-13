using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : PauseGameHandler, IGameStateBase, IMouseBehaviour, IRestartGame
{
    private GameStateManager _gameStateManager;
    public void OnStateEnter(GameStateManager gameState)
    {
        gameState.PauseMenu.SetActive(true);
        _gameStateManager = gameState;
        SetGameObjectsActive();
        ChangeMouseCursorBehaviour();
        ChangePauseTimeScale();
    }

    public void UpdateState(GameStateManager gameState)
    private void SetGameObjectsActive()
    {
        CheckPauseGame(gameState);
        CheckIfShouldResumeGame(gameState);
        if (GameStateManager.ShouldRestartGame)
        {
            gameState.SwitchState(gameState.RestartState);
        }
        _gameStateManager.PauseMenu.SetActive(true);
    }

    protected override void CheckPauseGame(GameStateManager gameState)
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PauseGameHandler.IsGamePaused)
        {
            PauseGameHandler.IsGamePaused = false;
            gameState.SwitchState(gameState.PlayState);
        }
    }

    protected override void ChangePauseTimeScale()
    {
        Time.timeScale = 0;
    }

    public void ChangeMouseCursorBehaviour()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void CheckIfShouldResumeGame(GameStateManager gameState)
    {
        if (PauseGameHandler.ShouldResumeGame)
        {
            PauseGameHandler.IsGamePaused = false;
            PauseGameHandler.ShouldResumeGame = false;
            gameState.SwitchState(gameState.PlayState);
            _gameStateManager.SwitchState(_gameStateManager.RestartState);
        }
    }
 
}
