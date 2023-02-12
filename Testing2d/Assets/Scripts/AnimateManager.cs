using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimateManager : MonoBehaviour
{
    [Header("Movement")]
    public float Speed = 1f;

    [Space]
    [Header("Animantion")]
    public Animator Anim;

    [Space]

    //PRIVATE VAR
    Rigidbody2D _rb;
    Vector2 _Direction;
    float MovementSpeed;



    void Start()
    {

        _rb = GetComponent<Rigidbody2D>();


    }
    // Update is called once per frame
    void Update()
    {
        GetInput();
        Animate();

    }

    private void FixedUpdate()
    {
        Move();
    }

    void GetInput()
    {
        _Direction.x = Input.GetAxisRaw("Horizontal");
        _Direction.y = Input.GetAxisRaw("Vertical");
    }
    void Move()
    {
        _rb.MovePosition(_rb.position + _Direction.normalized * Speed * Time.fixedDeltaTime);
        MovementSpeed = Mathf.Clamp(_Direction.magnitude, 0.0f, 1.0f);
    }

    void Animate()
    {
        if (_Direction != Vector2.zero)
        {
            Anim.SetFloat("Horizontal", _Direction.x);
            Anim.SetFloat("Vertical", _Direction.y);
        }
        Anim.SetFloat("Speed", MovementSpeed);
    }

}
