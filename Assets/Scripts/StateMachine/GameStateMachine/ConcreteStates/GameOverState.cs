using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : GameStateBase
{
    public void OnStateEnter(GameStateManager gameState)
    {
        Debug.Log("GAME OVER");
    }

    public void UpdateState(GameStateManager gameState)
    {
    }
}
