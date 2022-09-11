using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface GameStateBase
{
    public void OnStateEnter(GameStateManager gameState);
    public void UpdateState(GameStateManager gameState);
}
