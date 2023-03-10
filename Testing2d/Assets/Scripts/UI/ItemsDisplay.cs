using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemsDisplay : MonoBehaviour
{

    [Space(5)]
    [Header("UI elements")]
    public GameObject TradePanel; //UI element
    public TextMeshProUGUI NameField;
    public TextMeshProUGUI PriceField;
    public TextMeshProUGUI DamageField;
    public TextMeshProUGUI GoldPlayerField;
    public Image IconField;


    public Trader Trader;

    private int _indexUsed=0;
    private AssetItem _showItem;



    public void ShowUI()
    {
        if(TradePanel)
        {
            TradePanel.SetActive(true);
            GoldPlayerField.text = Trader.Customer.Money.ToString();
        }
    }
    public void NextItem()
    {
        if (_indexUsed == Trader.ItemList.Length - 1) _indexUsed = 0;
        else _indexUsed++;
        _showItem = Trader.ItemList[_indexUsed];
        SetItemUI();
    }
    public void PreviosItem()
    {
        if (_indexUsed == 0) _indexUsed = Trader.ItemList.Length - 1;
        else _indexUsed--;
        _showItem = Trader.ItemList[_indexUsed];
        SetItemUI();
    }
    public void HideUI()
    {
        if(TradePanel)
        {
            TradePanel.SetActive(false);
        }
    }

    private void SetItemUI()
    {
        NameField.text = _showItem.Name;
        IconField.sprite = _showItem.Icon;
        PriceField.text = _showItem.Price.ToString();
        if (_showItem is Weapon weapon)
        {
            DamageField.text = weapon._A1.ToString();
        }
        //if (_itemsUsed.name != null) name.text = _itemsUsed.name;
        //if (_itemsUsed.cost >= 0) price.text = _itemsUsed.cost.ToString();
        //if (_itemsUsed.damage >= 0) damage.text =  _itemsUsed.damage.ToString();
        //if (_itemsUsed.icon != null) icon.sprite = _itemsUsed.icon;
    }

}
