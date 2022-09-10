using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallAttributes))]
public class BallMovement : MonoBehaviour
{
    public RectTransform _rectTransform;
    public Vector2 _initialPosition;
    public Vector2 _positionToTranslate;

    private BallAttributes _ballAttributes;

    // Start is called before the first frame update
    void Start()
    {
        InitComponents();
        _initialPosition = _rectTransform.localPosition;
    }
    private void InitComponents()
    {
        _ballAttributes = GetComponent<BallAttributes>();
        _rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        MoveBall();
    }
    private void MoveBall()
    {
        _rectTransform.Translate(_positionToTranslate * _ballAttributes.MoveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BallHitter>() != null)
        {
            _positionToTranslate = collision.gameObject.GetComponent<BallHitter>().ChangeBallDirection(_positionToTranslate);
        }
    }
}
