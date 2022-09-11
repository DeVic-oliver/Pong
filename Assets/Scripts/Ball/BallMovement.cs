using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallAttributes))]
public class BallMovement : MonoBehaviour
{
    public RectTransform _rectTransform;
    public Vector2 _initialPosition;
    public Vector2 _positionToTranslate;

    [HeaderAttribute("Min and Max X Point Value to Translate")]
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
 
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


}
