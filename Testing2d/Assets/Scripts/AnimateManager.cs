using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimateManager : MonoBehaviour
{
    [Header("Movement")]
    public float Speed = 1f;

    [Space(2)]
    [Header("Animantion")]
    public Animator Anim;

    [Space(2)]
    [Header("UI")]
    public GameObject InventoryUI;
    //PRIVATE VAR
    Rigidbody2D _rb;
    Vector2 _Direction;
    float _movementSpeed;
    bool isOpenInventory = false;
    bool isCloseUI = false;
    bool _triggerAttack = false;
    bool _IsMoving = true;







    void Start()
    {

        _rb = GetComponent<Rigidbody2D>();


    }
    // Update is called once per frame
    void Update()
    {
        Animate();
        GetInput();
        ShowUI();

    }

    private void FixedUpdate()
    {
        _rb.WakeUp();   // ¬озможно нагрузит систему
        Move();

    }

    private void ShowUI()
    {
        // сделать список элементов(инвентарь,панель торговли и т.д.) чтобы на esc пройтись циклом и закрывать весь UI
        if (isOpenInventory)
        {
            InventoryUI.SetActive(true);
            Time.timeScale = 0.25f;
        }
        if (isCloseUI)
        {
            InventoryUI.SetActive(false);
            Time.timeScale = 1;
        }

    }

    void GetInput()
    {
        _triggerAttack = Input.GetKeyDown(KeyCode.Space);
        isOpenInventory = Input.GetKeyDown(KeyCode.Tab);
        isCloseUI = Input.GetKeyDown(KeyCode.Escape);
        _Direction.x = Input.GetAxisRaw("Horizontal");
        _Direction.y = Input.GetAxisRaw("Vertical");
    }
    void Move()
    {
        if (!_IsMoving) return;
        _rb.MovePosition(_rb.position + Speed * Time.fixedDeltaTime * _Direction.normalized);
        _movementSpeed = Mathf.Clamp(_Direction.magnitude, 0.0f, 1.0f);
    }

    void Animate()
    {
        if (_Direction != Vector2.zero)
        {
            Anim.SetFloat("Horizontal", _Direction.x);
            Anim.SetFloat("Vertical", _Direction.y);
        }
        Anim.SetFloat("Speed", _movementSpeed);
        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Blend Tree")) _IsMoving = true; // use animate tree MOVE (run or idle)
        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Blend Tree 0")) _IsMoving = false; // use animate tree ATTACK
        if (_triggerAttack) Anim.SetTrigger("Attack");

    }

}
