using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IDamagble
{
    public int MaxHealth =100;
    [SerializeField] private Animator _anim;
    [SerializeField] private Image _hpBar;
    //private int _health { get => _health; set => _health = Mathf.Clamp(_health, 0, MaxHealth); }
    private int _health { get; set; }

    private void Start()
    {
        _health = MaxHealth;
    }
    public void GetDamage(int damage)
    {
        _health -= damage;
        print(_health);
        if (_health <= 0) Dead();
    }

    public void Dead()
    {
        _anim.SetBool("Dead", true);

        Destroy(transform.parent.gameObject, 5f);

    }

}
