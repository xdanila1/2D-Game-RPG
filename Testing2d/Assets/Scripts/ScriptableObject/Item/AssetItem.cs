﻿using UnityEngine;

[CreateAssetMenu(fileName ="Item",menuName ="Item")]
public class AssetItem : ScriptableObject, IItem
{
    public string Name => _name;

    public Sprite Icon => _icon;

    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
}

