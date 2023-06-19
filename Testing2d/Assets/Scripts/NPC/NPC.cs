using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NPC : MonoBehaviour, IDamagble
{
    public bool GodMode=false;
    static public event Action<int> OnDead;
    [SerializeField]
    private int _health=100;
    [SerializeField]
    private int _money = 1000;
    private Animator _anim;
    private bool _flagDead = false;


    [SerializeField] private Image _hpbar;
    private AnimateWeapon _animWeapon;

    public int Health { get => _health; set => _health = Mathf.Clamp(_health,0, MaxHP); }
    public int Money { get => _money; private set => _money = value; }
    [SerializeField] private Inventory Inventory;

    [Range(100, 200)]
    public int MaxHP = 100;

    private void Start()
    {
        _hpbar.fillAmount = _health / MaxHP;
        _anim = GetComponent<Animator>();
        _animWeapon = GetComponentInChildren<AnimateWeapon>();
    }
    public void OnGodMode() => GodMode = true;
    public void AddMoney(int num) => _money += num;
    public void TakeMoney(int num) => _money -= num;
    //public void AddDamage(int num) => _health -= num;
    public void GetItem(AssetItem item)
    {
        Inventory.AddItem(item);
    }
 

    private void OnValidate() => Health = _health;
    private void Update()
    {
        _hpbar.fillAmount = (float)_health / (float)MaxHP;
        if (Input.GetKey(KeyCode.C)) Dead();
    }
    public void GetDamage(int damage)
    {
        _health -= damage;
        _hpbar.fillAmount = _health / MaxHP;
        if (_health <= 0 && !_flagDead)
        {
            
            Debug.Log("NPC умер");
           if(!GodMode) Dead();
        }
    }
    
    private void Dead()
    {
        _flagDead = true;
        _anim.SetBool("Dead", true);
        _animWeapon.CanAnimate = false;
        OnDead.Invoke(_money);
    }
}
