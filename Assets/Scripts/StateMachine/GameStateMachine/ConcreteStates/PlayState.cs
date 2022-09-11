using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : PauseGameHandler, GameStateBase, MouseBehaviour
{
    private GameStateManager _gameState;
    public void OnStateEnter(GameStateManager gameState)
    {
        _gameState = gameState;
        _gameState.PauseMenu.SetActive(false);
        PauseGameBehaviour();
        ChangeMouseCursorBehaviour();
        _gameState._gameManager.AllowBallToMove();
    }

    public void UpdateState(GameStateManager gameState)
    {
        _gameState._gameManager.ball.MoveBall();
        _gameState._gameManager.CheckIfPointWasMade();
        _gameState._gameManager._gameTimeHandler.DecreaseTime();
        CheckPauseGame(_gameState);
        CheckGameTime();
    }

    protected override void CheckPauseGame(GameStateManager gameState)
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

    private void CheckGameTime()
    {
        float gameTime = _gameState._gameManager._gameTimeHandler.CurrentTime;
        if (gameTime <= 0)
        {
            _gameState.SwitchState(_gameState.GameOverState);
        }
    }
}
