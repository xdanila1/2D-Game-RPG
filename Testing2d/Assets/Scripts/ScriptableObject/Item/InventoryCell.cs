using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class InventoryCell : MonoBehaviour, IPointerEnterHandler
{

    [SerializeField] private TextMeshProUGUI _nameField;
    [SerializeField] private Image _IconField;

    private string _damageItem;
    private string _priceItem;

    ///FIELD UI IN INVENTORY
    private Image _iconInventory;
    private TextMeshProUGUI _nameItemInventory;
    private TextMeshProUGUI _damageItemInventory;
    private TextMeshProUGUI _priceItemInventory;


    public void Render(IItem item, Image IconFieldInventory, TextMeshProUGUI NameFieldInventory, TextMeshProUGUI DamageFieldInventory, TextMeshProUGUI PriceFieldInventory)
    {
        _nameField.text = item.Name;

        if (item is Weapon weapon) _damageItem = weapon._A1.ToString();
        else _damageItem = "-";
        _priceItem = item.Price.ToString();

        // Fill links in Fields UI
        _IconField.sprite = item.Icon;
        _iconInventory = IconFieldInventory;
        _damageItemInventory = DamageFieldInventory;
        _priceItemInventory = PriceFieldInventory;
        _nameItemInventory = NameFieldInventory;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _nameItemInventory.text = _nameField.text;
        _iconInventory.sprite = _IconField.sprite;

        _damageItemInventory.text = _damageItem;
        _priceItemInventory.text = _priceItem;
    }
}

