using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAttack : MonoBehaviour
{
    private Collider2D obj;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        obj = collision;
        Debug.Log(collision.gameObject.name);
        Attack();
    }
    
    public void Attack()
    {
        Debug.Log("”дар по:"+ obj);
    }
}
