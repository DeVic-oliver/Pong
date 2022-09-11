public abstract class PauseGameHandler
{
    public static bool IsGamePaused;
    public static bool ShouldResumeGame;
    protected abstract void CheckPauseGame(GameStateManager gameState);
    protected abstract void PauseGameBehaviour();
    protected abstract void ChangeMouseCursorBehaviour();
}
