using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<AssetItem> Items;
    [SerializeField] private InventoryCell _ItemCellTemplate;
    [SerializeField] private Transform _Content;
    [Space(10)]

    [Header("UI FIELD INVENTORY")]
    [SerializeField] private Image _iconItemInventory;
    [SerializeField] private TextMeshProUGUI _damageItemInventory;
    [SerializeField] private TextMeshProUGUI _priceItemInventory;
    [SerializeField] private TextMeshProUGUI _nameItemInventory;


    private void OnEnable()
    {
        Render( Items);
    }

    private void Render(List<AssetItem> items)
    {
        foreach (Transform child in _Content) Destroy(child.gameObject);
        items.ForEach(item =>
        {
            var cell = Instantiate(_ItemCellTemplate, _Content);
            cell.Render(item, _iconItemInventory, _nameItemInventory,_damageItemInventory, _priceItemInventory);
        });
    }
    public void AddItem(AssetItem item)
    {
        Items.Add(item);
    }
}

