using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IDamagble
{
    [SerializeField]
    private int _health=100;
    [SerializeField]
    private int _money = 1000;
    
    
    public int Health { get => _health; set => _health = Mathf.Clamp(_health,0, MaxHP); }
    public int Money { get => _money; private set => _money = value; }
    [SerializeField] private Inventory Inventory;

    [Range(100, 200)]
    public int MaxHP = 100;


    public void AddMoney(int num) => _money += num;
    public void TakeMoney(int num) => _money -= num;
    public void AddDamage(int num) => _health -= num;
    public void GetItem(AssetItem item)
    {
        Inventory.AddItem(item);
    }
 

    private void OnValidate() => Health = _health;

    public void GetDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0) Debug.Log("NPC умер");
    }
}
