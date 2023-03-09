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
        isOpenInventory = Input.GetKeyDown(KeyCode.Tab);
        isCloseUI = Input.GetKeyDown(KeyCode.Escape);
        _Direction.x = Input.GetAxisRaw("Horizontal");
        _Direction.y = Input.GetAxisRaw("Vertical");
    }
    void Move()
    {
        _rb.MovePosition(_rb.position + _Direction.normalized * Speed * Time.fixedDeltaTime);
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
    }

}
