using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private int _health=100;
    [SerializeField]
    private int _money = 1000;
    
    public int Health { get => _health; set => _health = Mathf.Clamp(_health,0, MaxHP); }
    public int Money { get => _money; set => _money = value; }

    [Range(100, 200)]
    public int MaxHP = 100;


    public void AddMoney(int num) => _money += num;
    public void TakeMoney(int num) => _money -= num;
    public void AddDamage(int num) => _health -= num;
 

    private void OnValidate() => Health = _health;
    
}
