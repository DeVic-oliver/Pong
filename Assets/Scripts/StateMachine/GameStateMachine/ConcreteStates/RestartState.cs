using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartState : PauseGameHandler, IGameStateBase
{
    private float stateChangerCounter = 3f;
    private GameStateManager _gameStateManager;
    public void OnStateEnter(GameStateManager gameState)
    {
        _gameStateManager = gameState;
        gameState._gameManager._gameTimeHandler.ResetTime();
        gameState._gameManager.ball.RestartBallPosition();
        gameState._gameManager._gameScoreHandler.ResetPlayerPoints();
    }

    public void UpdateState(GameStateManager gameState)
    {
        CountToChangeState();
    }

    private void CountToChangeState()
    {
        if(stateChangerCounter > 0)
        {
            stateChangerCounter -= Time.deltaTime;
        }
        else
        {
            _gameState.SwitchState(_gameState.PlayState);
        }
    }
}
