using UnityEngine;

[CreateAssetMenu(fileName ="Item",menuName ="Item/AssetItem")]
public class AssetItem : ScriptableObject, IItem
{
    public string Name => _name;
    public Sprite Icon => _icon;
    public int Price => _price;

    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _price;
}

