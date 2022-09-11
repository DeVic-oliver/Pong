using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : GameStateBase
{
    public void OnStateEnter(GameStateManager gameState)
    {
        gameState._gameManager.ChangeBallMovePermission(true);
    }

    public void UpdateState(GameStateManager gameState)
    {
        throw new System.NotImplementedException();
    }
}
