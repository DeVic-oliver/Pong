using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : PauseGameHandler, GameStateBase
{
    public void OnStateEnter(GameStateManager gameState)
    {
        PauseGameBehaviour();
    }

    public void UpdateState(GameStateManager gameState)
    {
        CheckPauseGame(gameState);
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
}
