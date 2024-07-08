using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCharacter : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3 _input;
    private bool _isMoving;

    private Rigidbody2D _rigidbody;
    private CharacterAnimation _animations;
    [SerializeField] private SpriteRenderer _characterSprite;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animations = GetComponentInChildren<CharacterAnimation>();
    }

    
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"), 0);
        transform.position += _input * _speed * Time.deltaTime;
        _isMoving = _input.x != 0 ? true : false;

        if (_isMoving)
        {
            _characterSprite.flipX = _input.x > 0 ? false : true;
        }

        _animations.IsMoving = _isMoving;
    }
}
