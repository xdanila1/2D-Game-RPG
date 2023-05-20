using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackZone : MonoBehaviour
{
    [SerializeField] LayerMask Layer;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((Layer.value & (1 << collision.gameObject.layer)) > 0)
        {
            print("Враг задет");
            IDamagble damagble = collision.GetComponent<IDamagble>();
            damagble.GetDamage(30);
        }
        else print("Это не противник");

        
    }
}
