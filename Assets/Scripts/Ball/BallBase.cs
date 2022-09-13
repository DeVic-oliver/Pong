using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBase : MonoBehaviour
{
    public float MoveSpeed = 240f;
    [SerializeField] private float CooldownToStartMove = 1f;
    public bool IsBallAllowedToMove { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IScoreable>() != null)
        {
            collision.gameObject.GetComponent<IScoreable>().ApplyScore();
        }
    }

    /// <summary>
    /// Changes the ball movement permission based on a bool param. If true the ball will move after a 2 seconds cooldown. 
    /// </summary>
    /// <param name="canBallMove">The ball move permission</param>
    public void ChangeBallMovePermission(bool canBallMove)
    {
        if (canBallMove)
        {
            StartCoroutine(CooldownToMove());
        }
        else
        {
            IsBallAllowedToMove = canBallMove;
        }
    }
    private IEnumerator CooldownToMove()
    {
        yield return new WaitForSeconds(CooldownToStartMove);
        IsBallAllowedToMove = true;
    }
}
