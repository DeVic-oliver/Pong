using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : IGameStateBase
{
    public void OnStateEnter(GameStateManager gameState)
    {
        gameState._gameManager.DenyBallToMove();
    }

    public void UpdateState(GameStateManager gameState)
    {
        if (gameState._gameManager.CanBeginGame)
        {
            gameState.SwitchState(gameState.PlayState);
        }
    }
}
