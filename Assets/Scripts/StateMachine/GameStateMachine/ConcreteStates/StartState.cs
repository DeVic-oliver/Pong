using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : IGameStateBase, IMouseBehaviour
{
   

    public void OnStateEnter(GameStateManager gameState)
    {
        GameStateManager.ShouldBackToMainMenu = false;
        Player.shouldSetName = false; 
        gameState._gameManager.CanBeginGame = false;

        ChangeMouseCursorBehaviour();

        gameState._gameManager.DenyBallToMove();
        gameState._gameManager._gameScoreHandler.ResetScoreboard();
        gameState._gameManager._gameScoreHandler.Player1.ResetName();
        gameState._gameManager._gameScoreHandler.Player2.ResetName();
        gameState._gameManager._gameTimeHandler.ResetTime();

    }
    public void ChangeMouseCursorBehaviour()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void UpdateState(GameStateManager gameState)
    {
        if (gameState._gameManager.CanBeginGame)
        {
            gameState.SwitchState(gameState.PlayState);
        }
    }
}
