using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateWeapon : MonoBehaviour
{
    private Animator _anim;
    private Vector2 _Direction;

    void Start()
    {
        _anim = GetComponent<Animator>();   
    }


    void Update()
    {
        Animate();
        GetInput();
    }

    private void GetInput()
    {
        _Direction.x = Input.GetAxisRaw("Horizontal");
        _Direction.y = Input.GetAxisRaw("Vertical");
    }

    void Animate()
    {
        if(_Direction !=Vector2.zero)
        {
            _anim.SetFloat("Horizontal", _Direction.x);
            _anim.SetFloat("Vertical", _Direction.y);
        }
        if (Input.GetKeyDown(KeyCode.Space)) _anim.SetTrigger("Attack");
    }
}
