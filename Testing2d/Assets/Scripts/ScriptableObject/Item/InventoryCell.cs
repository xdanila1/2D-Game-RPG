using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryCell : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameField;
    [SerializeField] private Image _IconField;


    public void Render(IItem item)
    {
        _nameField.text = item.Name;
        _IconField.sprite = item.Icon;
    }
}

