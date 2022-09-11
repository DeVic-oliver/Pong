using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    private bool canBeginGame = false;
    public bool CanBeginGame 
    { 
        get { return canBeginGame; } 
        private set { canBeginGame = value; } 
    }

    public BallMovement ball;
    public GameTimeHandler _gameTimeHandler;
    public GameScoreHandler _gameScoreHandler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfPointWasMade();
    }
    public void CheckIfPointWasMade()
    {
        if (PointBoundary.IsPointMade)
        {
            ball.ChangeBallMovePermission(false);
            ball.RestartBallPosition();
            PointBoundary.IsPointMade = false;
        }
    }

    /// <summary>
    /// Allows begin the game leaving the starte state and going to play state on the game state machine  
    /// </summary>
    public void AllowGameBegin()
    {
        CanBeginGame = true;
    }

    /// <summary>
    /// Allows the ball to move.
    /// </summary>
    public void AllowBallToMove()
    {
        ball.ChangeBallMovePermission(true);
    }

    /// <summary>
    /// Denies the ball to move.
    /// </summary>
    public void DenyBallToMove()
    {
        ball.ChangeBallMovePermission(false);
    }

    public void ResumeGame()
    {
        PauseGameHandler.ShouldResumeGame = true;
    }

    public void RestartGame()
    {
        GameStateManager.ShouldRestartGame = true;
    }
}
