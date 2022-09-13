using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameStateBase
{
    public void OnStateEnter(GameStateManager gameState);
    public void UpdateState(GameStateManager gameState);
}
