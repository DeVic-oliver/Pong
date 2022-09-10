using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private RectTransform _rectTransform;
    private Rigidbody2D _rigidbody;
    [SerializeField] private float moveSpeed = 1000f;
    [SerializeField] private KeyCode keyToMoveUp;
    [SerializeField] private KeyCode keyToMoveDown;

    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        if( Input.GetKey(keyToMoveUp))
        {
            _rigidbody.MovePosition(_rectTransform.position + Vector3.up * moveSpeed * Time.deltaTime);
        }else if( Input.GetKey(keyToMoveDown) )
        {
            _rigidbody.MovePosition(_rectTransform.position +  Vector3.down * moveSpeed * Time.deltaTime);
        }
    }
}
