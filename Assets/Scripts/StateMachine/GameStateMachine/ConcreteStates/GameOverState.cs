using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : GameStateBase, MouseBehaviour
{
 
    public void OnStateEnter(GameStateManager gameState)
    {
        gameState.GameOverMenu.SetActive(true);
        ChangeMouseCursorBehaviour();
    }

    public void UpdateState(GameStateManager gameState)
    {
        if (GameStateManager.ShouldRestartGame)
        {
            gameState.SwitchState(gameState.RestartState);
        }
    }

    public void ChangeMouseCursorBehaviour()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

}
