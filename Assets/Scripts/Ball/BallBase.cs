using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBase : MonoBehaviour
{
    public float MoveSpeed = 240f;
    public float CooldownToStartMove = 2f;
    public bool IsBallAllowedToMove { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

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
