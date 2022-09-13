using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartState : PauseGameHandler, IGameStateBase
{
    private float stateChangerCounterValue = 1f;
    private float stateChangerCounter;
    private GameStateManager _gameStateManager;
    public void OnStateEnter(GameStateManager gameState)
    {
        _gameStateManager = gameState;
        stateChangerCounter = stateChangerCounterValue;
        gameState._gameManager._gameTimeHandler.ResetTime();
        gameState._gameManager.ball.RestartBallPosition();
        gameState._gameManager._gameScoreHandler.ResetPlayerPoints();

        GameStateManager.ShouldRestartGame = false;  
    }

    public void UpdateState(GameStateManager gameState)
    {
        CountToChangeState();
    }
    private void CountToChangeState()
    {
        if (stateChangerCounter > 0)
        {
            stateChangerCounter -= Time.deltaTime;
        }
        else
        {
            _gameState.SwitchState(_gameState.PlayState);
            stateChangerCounter = stateChangerCounterValue;
        }
    }
}
