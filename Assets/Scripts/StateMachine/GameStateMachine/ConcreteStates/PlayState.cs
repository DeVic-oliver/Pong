using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : PauseGameHandler, IGameStateBase, IMouseBehaviour
{
    private GameStateManager _gameStateManager;
    public void OnStateEnter(GameStateManager gameState)
    {
        _gameState = gameState;
        _gameState.PauseMenu.SetActive(false);
        PauseGameBehaviour();
        ChangeMouseCursorBehaviour();
        _gameState._gameManager.AllowBallToMove();
    }
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !PauseGameHandler.IsGamePaused)
        {
            PauseGameHandler.IsGamePaused = true;
            gameState.SwitchState(gameState.PauseState);
        }
    }
    protected override void PauseGameBehaviour()
    {
        Time.timeScale = 1;
    }
    public void ChangeMouseCursorBehaviour()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
        float gameTime = _gameState._gameManager._gameTimeHandler.CurrentTime;
        if (gameTime <= 0)
        {
            _gameState.SwitchState(_gameState.GameOverState);
        }
    }
}
