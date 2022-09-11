using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : PauseGameHandler, GameStateBase, MouseBehaviour
{
    public void OnStateEnter(GameStateManager gameState)
    {
        gameState.PauseMenu.SetActive(true);
        ChangeMouseCursorBehaviour();
        PauseGameBehaviour();
    }

    public void UpdateState(GameStateManager gameState)
    {
        CheckPauseGame(gameState);
        CheckIfShouldResumeGame(gameState);
        if (GameStateManager.ShouldRestartGame)
        {
            gameState.SwitchState(gameState.RestartState);
        }
    }

    protected override void CheckPauseGame(GameStateManager gameState)
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PauseGameHandler.IsGamePaused)
        {
            PauseGameHandler.IsGamePaused = false;
            gameState.SwitchState(gameState.PlayState);
        }
    }

    protected override void PauseGameBehaviour()
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
        }
    }
 
}
