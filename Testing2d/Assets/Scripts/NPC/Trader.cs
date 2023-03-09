using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trader : MonoBehaviour
{

    public AssetItem[] ItemList;
    [Space(5)]
    public ItemsDisplay TradeUI;

    private Collider2D _areaTrade;
    public NPC _customer;

    private void Start()
    {
        _areaTrade = GetComponent<Collider2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E)) Trade(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.GetComponent<NPC>() == _customer)  TradeUI.HideUI();
    }
    private void Trade(Collider2D collision)
    {
        _customer = collision.GetComponent<NPC>();
        TradeUI.Trader = this;
        TradeUI.ShowUI();
    }

}
