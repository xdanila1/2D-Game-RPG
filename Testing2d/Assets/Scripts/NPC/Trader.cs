using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trader : MonoBehaviour
{
    [Space(5)]
    [Header("List Item")]
    public AssetItem[] ItemList;
    [HideInInspector] public NPC Customer { get => _customer; set => _customer = value; }

    [Space(5)]
    [Header("Trade UI")]
    [SerializeField] private GameObject _TextHint;  // object with textMeshPro
    [SerializeField] private ItemsDisplay TradeUI;

    private NPC _customer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<NPC>()) _TextHint.SetActive(true);
        if (Input.GetKey(KeyCode.E)) Trade(collision);
        if (Input.GetKey(KeyCode.Escape)) TradeUI.HideUI();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<NPC>()) _TextHint.SetActive(false);
        if (collision.GetComponent<NPC>() == Customer)  TradeUI.HideUI();
    }
    private void Trade(Collider2D collision)
    {
        Customer = collision.GetComponent<NPC>();
        TradeUI.Trader = this;
        TradeUI.ShowUI();
    }
    public void ToSell(int number)
    {
        if(_customer.Money >= ItemList[number].Price)
        {

        _customer.TakeMoney(ItemList[number].Price);
        _customer.GetItem(ItemList[number]);
        }
    }

}
