using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : PauseGameHandler, GameStateBase
{
    public void OnStateEnter(GameStateManager gameState)
    {
        gameState.PauseMenu.SetActive(false);
        PauseGameBehaviour();
        ChangeMouseCursorBehaviour();
        gameState._gameManager.AllowBallToMove();
    }

    public void UpdateState(GameStateManager gameState)
    {
        gameState._gameManager.ball.MoveBall();
        gameState._gameManager.CheckIfPointWasMade();
        gameState._gameManager._gameTimeHandler.DecreaseTime();
        CheckPauseGame(gameState);
    }

    protected override void CheckPauseGame(GameStateManager gameState)
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !PauseGameHandler.IsGamePaused)
        {
            PauseGameHandler.IsGamePaused = true;
            gameState.SwitchState(gameState.PauseState);
        }
    }
    protected override void PauseGameBehaviour()
    {
        Time.timeScale = 1;
    }
    protected override void ChangeMouseCursorBehaviour()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
