using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class playerControler : MonoBehaviour
{
    
    [SerializeField]private Animator animator;

    [SerializeField] private float speed = 1f;
    [SerializeField] private float maxSpeed = 1f;
    
    [SerializeField] private GameObject bullet;
    
    private bool _up;
    private bool _down;
    private bool _left;
    private bool _right;
    private bool _isWalking;
    private bool _leftClick;

    private SpriteRenderer _sr;
    private Rigidbody2D _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("up",_up);
        animator.SetBool("down",_down);
        animator.SetBool("side",_left);
        if (_left == false)
        {
            animator.SetBool("side",_right);
        }
        if (_left&&!_right)
        {
            _sr.flipX = false;
        }
        else if (_right&&!_left)
        {
            _sr.flipX = true;
        }

        Vector2 velocity = _rb.velocity;
        if (_up)
        {
            velocity += Vector2.up * (speed);
        }
        if (_down)
        {
            velocity += Vector2.down*(speed);
        }
        if (_left&&!_right)
        {
            velocity += Vector2.left*(speed);
        }
        if (_right&&!_left)
        {
            velocity += Vector2.right*(speed);
        }
        if (!_left&&!_right&&!_down&&!_up)
        {
            velocity = _rb.velocity / 1.5f;
        }

        if (velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }
        
        _rb.velocity = velocity;
        
        if (_rb.velocity.magnitude>0.001)
        {
            animator.SetBool("walk",true);
        }
        else
        {
            animator.SetBool("walk",false);
        }

        if (_leftClick)
        {
            Shoot();
        }

    }

    private void Shoot()
    {
        Instantiate(bullet,transform.position,Quaternion.identity);
    }

    public void OnUp(InputValue value)
    {
        _up = value.isPressed;
    }
    public void OnDown(InputValue value)
    {
        _down = value.isPressed;
    }
    public void OnLeft(InputValue value)
    {
        _left = value.isPressed;
    }
    public void OnRight(InputValue value)
    {
        _right = value.isPressed;
    }
    public void OnLeftClick(InputValue value)
    {
        _leftClick = value.isPressed;
    }
    
}


