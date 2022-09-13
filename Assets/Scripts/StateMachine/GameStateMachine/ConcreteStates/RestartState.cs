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
        ChangePauseTimeScale();
        
        gameState._gameManager.DenyBallToMove();
        gameState._gameManager._gameTimeHandler.ResetTime();
        gameState._gameManager.ball.RestartBallPosition();
        gameState._gameManager._gameScoreHandler.ResetScoreboard();

        GameStateManager.ShouldRestartGame = false;  
    }
    protected override void ChangePauseTimeScale()
    {
        Time.timeScale = 1;
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
            stateChangerCounter = stateChangerCounterValue;
            _gameStateManager.SwitchState(_gameStateManager.PlayState);
        }
    }
}
