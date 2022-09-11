using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : BallBase
{
    public RectTransform _rectTransform;
    public Vector2 _initialPosition;
    public Vector2 _positionToTranslate;

    [HeaderAttribute("Min and Max X Point Value to Translate")]
    [SerializeField] private float minX;
    [SerializeField] private float maxX;

    // Start is called before the first frame update
    void Start()
    {
        InitComponents();
        _initialPosition = _rectTransform.localPosition;
    }
    private void InitComponents()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        
    }

    /// <summary>
    /// Move the ball when the ball its allowed to move
    /// </summary>
    public void MoveBall()
    {
        if (IsBallAllowedToMove)
        {
            _rectTransform.Translate(_positionToTranslate * MoveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            ChangeXDirection();
        }

        if (collision.gameObject.CompareTag("Boundary"))
        {
            ChangeYDirection();
        }
    }

    private void ChangeXDirection()
    {
        float newPositionValue = Random.Range(minX, maxX);
        _positionToTranslate.x = VectorAxisValueChanger.ChangeVectorAxisValue(_positionToTranslate.x, newPositionValue);
    }

    private void ChangeYDirection()
    {
        _positionToTranslate.y *= -1;
    }

    /// <summary>
    /// Randomize the ball direction based in a point on X axis;
    /// </summary>
    private void RandomBallMoveDirection()
    {
        ChangeXDirection();
    }

    /// <summary>
    /// Restarts the ball its to initial position; 
    /// </summary>
    public void RestartBallPosition()
    {
        _rectTransform.localPosition = _initialPosition;
        RandomBallMoveDirection();
        ChangeBallMovePermission(true);
    }


}
