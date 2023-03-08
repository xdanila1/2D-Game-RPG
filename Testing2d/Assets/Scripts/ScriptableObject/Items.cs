using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(fileName ="Item", menuName ="Item")]
public class Items : ScriptableObject
{
    public new string name;
    public int cost;

    public Sprite icon;

    public int damage;

}
