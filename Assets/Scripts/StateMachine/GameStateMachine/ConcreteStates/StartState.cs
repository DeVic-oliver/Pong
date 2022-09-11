using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : GameStateBase
{
    public void OnStateEnter(GameStateManager gameState)
    {
        gameState._gameManager.ChangeBallMovePermission(false);
    }

    public void UpdateState(GameStateManager gameState)
    {
        if (gameState._gameManager.CanBeginGame)
        {
            gameState.SwitchState(gameState.PlayState);
        }
    }
}
