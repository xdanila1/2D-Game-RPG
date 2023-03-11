using UnityEngine;
using System.Collections.Generic;
using System;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<AssetItem> Items;
    [SerializeField] private InventoryCell _ItemCellTemplate;
    [SerializeField] private Transform _Content;


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
            cell.Render(item);
        });
    }
    public void AddItem(AssetItem item)
    {
        Items.Add(item);
    }
}

