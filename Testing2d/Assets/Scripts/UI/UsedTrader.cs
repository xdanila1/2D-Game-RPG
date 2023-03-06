using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsedTrader : MonoBehaviour
{
    public ItemsDisplay Trader;



    // Удалить.

    public void next() => Trader.NextItem();
    public void previos() => Trader.PreviosItem();
}
