using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour, IDamagble
{
    public int MaxHealth =100;
    [Range(0,60)]
    public int MinReward = 5;
    [Range(10,125)]
    public int MaxReward = 125;
    [SerializeField] private TextMeshProUGUI MoneyUI;
    [SerializeField] private NPC _player;
    [SerializeField] private Animator _anim;
    [SerializeField] private GameObject _panelPickUp;
    [SerializeField] private GameObject _hPMask;
    [SerializeField] private Image _hpBar;
    private int _reward;
    private bool _IsDead=false;
    //private int _health { get => _health; set => _health = Mathf.Clamp(_health, 0, MaxHealth); }
    private int _health { get; set; }

    private void Start()
    {
        _player = FindObjectOfType<NPC>();
        _reward = UnityEngine.Random.Range(MinReward, MaxReward);
        MoneyUI.text =_reward+"";
        _health = MaxHealth;

    }
    public void GetDamage(int damage)
    {
        _health -= damage;
        _hpBar.fillAmount = (_hpBar.fillAmount*100 - damage) / 100;
        print(_health);
        if (_health <= 0 && !_IsDead) Dead();
    }

    public void Dead()
    {
        _IsDead = true;
        print(_health);
        _player.AddMoney(_reward);
        _anim.SetBool("Dead", true);
        _panelPickUp.SetActive(true);
        _hPMask.SetActive(false);
        Destroy(transform.parent.gameObject, 5f);

    }

}
