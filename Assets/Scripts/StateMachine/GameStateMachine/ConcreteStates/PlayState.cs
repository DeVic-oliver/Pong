using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : PauseGameHandler, IGameStateBase, IMouseBehaviour
{
    private GameStateManager _gameStateManager;
    public void OnStateEnter(GameStateManager gameState)
    {
        _gameStateManager = gameState;
        DeactiveGameObjects();
        ChangePauseTimeScale();
        ChangeMouseCursorBehaviour();
        gameState._gameManager.AllowBallToMove();
        SetPlayerName();
    }
    private void DeactiveGameObjects()
    {
        _gameStateManager.PauseMenu.SetActive(false);
    }
    protected override void ChangePauseTimeScale()
    {
        Time.timeScale = 1;
    }
    public void ChangeMouseCursorBehaviour()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void SetPlayerName()
    {
        Player.shouldSetName = true;
    }

    public void UpdateState(GameStateManager gameState)
    {
        gameState._gameManager.ball.MoveBall();
        gameState._gameManager.CheckIfPointWasMade();
        gameState._gameManager._gameTimeHandler.DecreaseTime();
        ChangeGameStateBetweenPauseAndPlay(gameState);
        CheckGameTime();
    }
    private void CheckGameTime()
    {
        float gameTime = _gameStateManager._gameManager._gameTimeHandler.CurrentTime;
        if (gameTime <= 0)
        {
            _gameStateManager.SwitchState(_gameStateManager.GameOverState);
        }
    }
}
