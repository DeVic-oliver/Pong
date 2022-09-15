using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : IGameStateBase, IMouseBehaviour, IRestartGame
{
    private GameStateManager _gameStateManager;
    public void OnStateEnter(GameStateManager gameState)
    {
        _gameStateManager = gameState;
        gameState._gameManager._gameScoreHandler.SetGameWinner();
        gameState.GameOverMenu.SetActive(true);
        ChangeMouseCursorBehaviour();
    }
    public void ChangeMouseCursorBehaviour()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void UpdateState(GameStateManager gameState)
    {
        CheckIfShouldRestartGame();
        CheckIfShouldBackToMainMenu();
    }
    public void CheckIfShouldRestartGame()
    {
        if (GameStateManager.ShouldRestartGame)
        {
            _gameStateManager.SwitchState(_gameStateManager.RestartState);
        }
    }
    public void CheckIfShouldBackToMainMenu()
    {
        if (GameStateManager.ShouldBackToMainMenu)
        {
            _gameStateManager.SwitchState(_gameStateManager.StartState);
        }
    }

  

 
}
