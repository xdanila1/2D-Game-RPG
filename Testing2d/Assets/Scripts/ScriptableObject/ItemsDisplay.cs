using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemsDisplay : MonoBehaviour
{
    [Header("List Array for Trade")]
    [ContextMenuItem("LogPropertyItems", "LogItem")]
    [ContextMenuItem("NextItem", "NextItem")]
    [ContextMenuItem("PreviosItem", "PreviosItem")]
    [ContextMenuItem("SetItem", "SetItemUI")]
    public Items[] Item;

    [Space(5)]
    [Header("UI")]
    public new TextMeshProUGUI name;
    public TextMeshProUGUI price;
    public TextMeshProUGUI damage;
    public TextMeshProUGUI GoldPlayer;
    public Image icon;
    public GameObject tradePanel; //UI element
    public UsedTrader Trader;

    [SerializeField]
    private int _number_used=0;
    private Collider2D _areaTrade;
    private Items _items_used;

    private void Start()
    {
        _items_used = Item[_number_used];
        _areaTrade = GetComponent<Collider2D>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.GetComponent<NPC>())
        {
            if (Input.GetKey(KeyCode.E))
            {
                GoldPlayer.text = other.GetComponent<NPC>().Money.ToString();
                Trade();
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                Debug.Log("PRESSED ESCAPE");
                OutTrade();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<NPC>())
        {
            OutTrade();
        }
    }

    void Trade()
    {
        Trader.Trader = this;
        if(tradePanel)
        {
            tradePanel.SetActive(true);
        }
    }
    void OutTrade()
    {
        if(tradePanel)
        {
            tradePanel.SetActive(false);
        }
    }

    public void SetItemUI()
    {
        if (_items_used.name != null) name.text = _items_used.name;
        if (_items_used.cost >= 0) price.text = _items_used.cost.ToString();
        if (_items_used.damage >= 0) damage.text =  _items_used.damage.ToString();
        if (_items_used.icon != null) icon.sprite = _items_used.icon;
    }

    public void NextItem()
    {
        if (_number_used == Item.Length - 1) _number_used = 0;
        else _number_used++;
        _items_used = Item[_number_used];
        SetItemUI();
    }
    public void PreviosItem()
    {
        if (_number_used == 0) _number_used = Item.Length - 1;
        else _number_used--;
        _items_used = Item[_number_used];
        SetItemUI();
    }



    void LogItem()
    {
        foreach(Items a in Item)
        {
            Debug.Log($"Name: {a.name} Damage:{a.damage} Cost: {a.cost}  ");
        }
    }
}
