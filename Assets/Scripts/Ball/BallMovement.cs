using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public RectTransform _rectTransform;
    public Vector2 _initialPosition;
    public Vector2 _positionToTranslate;
    public float MoveSpeed = 100f;

    private string _playerTag;
    private string _obstacleTag;

    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _initialPosition = _rectTransform.localPosition;
    }

    void Update()
    {
        MoveBall();
    }
    private void MoveBall()
    {
        _rectTransform.Translate(_positionToTranslate * MoveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BallHitter>() != null)
        {
            _positionToTranslate = collision.gameObject.GetComponent<BallHitter>().ChangeBallDirection(_positionToTranslate);
        }
    }
    private void RandomizeMoveSpeed()
    {
        MoveSpeed = Random.Range(140f, 180f);
    }

}
