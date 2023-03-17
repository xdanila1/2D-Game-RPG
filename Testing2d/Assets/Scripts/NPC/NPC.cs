using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour, IDamagble
{
    [SerializeField]
    private int _health=100;
    [SerializeField]
    private int _money = 1000;

    [SerializeField] private Image _hpbar;


    public int Health { get => _health; set => _health = Mathf.Clamp(_health,0, MaxHP); }
    public int Money { get => _money; private set => _money = value; }
    [SerializeField] private Inventory Inventory;

    [Range(100, 200)]
    public int MaxHP = 100;

    private void Start()
    {
        _hpbar.fillAmount = _health / MaxHP;
    }

    public void AddMoney(int num) => _money += num;
    public void TakeMoney(int num) => _money -= num;
    public void AddDamage(int num) => _health -= num;
    public void GetItem(AssetItem item)
    {
        Inventory.AddItem(item);
    }
 

    private void OnValidate() => Health = _health;
    private void Update()
    {
        _hpbar.fillAmount = (float)_health / (float)MaxHP;
    }
    public void GetDamage(int damage)
    {
        _health -= damage;
        _hpbar.fillAmount = _health / MaxHP;
        if (_health <= 0) Debug.Log("NPC умер");
    }
}
