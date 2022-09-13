using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartState : PauseGameHandler, IGameStateBase
{
    private float stateChangerCounter = 3f;
    private GameStateManager _gameStateManager;
    public void OnStateEnter(GameStateManager gameState)
    {
        Debug.Log("Entrou no restart state");
        _gameState = gameState;
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
            Debug.Log("Entrou no contador do restart");
            stateChangerCounter -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Mudando para Play State");
            _gameState.SwitchState(_gameState.PlayState);
        }
    }
}
