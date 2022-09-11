public abstract class PauseGameHandler
{
    public static bool IsGamePaused;
    protected abstract void CheckPauseGame(GameStateManager gameState);
    protected abstract void PauseGameBehaviour();
}
