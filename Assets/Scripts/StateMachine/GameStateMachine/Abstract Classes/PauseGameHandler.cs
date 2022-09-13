using UnityEngine;
public abstract class PauseGameHandler
{
    public static bool IsGamePaused;
    public static bool ShouldResumeGame;
    
    /// <summary>
    /// Change the time scale when pauses or resume game
    /// </summary>
    protected abstract void ChangePauseTimeScale();

    /// <summary>
    /// Change game state between the pause state and play state.
    /// </summary>
    /// <param name="gameState">Receives state manager</param>
    protected void ChangeGameStateBetweenPauseAndPlay(GameStateManager gameState)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CheckIfGameIsPaused(gameState);
        }
    }
    private void CheckIfGameIsPaused(GameStateManager gameState)
    {
        if (!PauseGameHandler.IsGamePaused)
        {
            PauseGameHandler.IsGamePaused = true;
            gameState.SwitchState(gameState.PauseState);
        }
        else if (PauseGameHandler.IsGamePaused)
        {
            PauseGameHandler.IsGamePaused = false;
            gameState.SwitchState(gameState.PlayState);
        }
    }
}
