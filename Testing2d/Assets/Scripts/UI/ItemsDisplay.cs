using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemsDisplay : MonoBehaviour
{

    [Space(5)]
    [Header("UI elements")]
    public GameObject tradePanel; //UI element
    public new TextMeshProUGUI name;
    public TextMeshProUGUI price;
    public TextMeshProUGUI damage;
    public TextMeshProUGUI GoldPlayer;
    public Image icon;

    public Trader Trader;

    [SerializeField]
    private int _indexUsed=0;
    private Items _itemsUsed;

    private void Start()
    {
        //_items_used = Trader.ItemList[_number_used];
    }


    public void ShowUI()
    {
        if(tradePanel)
        {
            tradePanel.SetActive(true);
            GoldPlayer.text = Trader._customer.Money.ToString();
        }
    }
    public void NextItem()
    {
        if (_indexUsed == Trader.ItemList.Length - 1) _indexUsed = 0;
        else _indexUsed++;
        _itemsUsed = Trader.ItemList[_indexUsed];
        SetItemUI();
    }
    public void PreviosItem()
    {
        if (_indexUsed == 0) _indexUsed = Trader.ItemList.Length - 1;
        else _indexUsed--;
        _itemsUsed = Trader.ItemList[_indexUsed];
        SetItemUI();
    }
    public void HideUI()
    {
        if(tradePanel)
        {
            tradePanel.SetActive(false);
        }
    }

    private void SetItemUI()
    {
        if (_itemsUsed.name != null) name.text = _itemsUsed.name;
        if (_itemsUsed.cost >= 0) price.text = _itemsUsed.cost.ToString();
        if (_itemsUsed.damage >= 0) damage.text =  _itemsUsed.damage.ToString();
        if (_itemsUsed.icon != null) icon.sprite = _itemsUsed.icon;
    }


    void LogItem()
    {
        foreach(Items a in Trader.ItemList)
        {
            Debug.Log($"Name: {a.name} Damage:{a.damage} Cost: {a.cost}  ");
        }
    }
}
