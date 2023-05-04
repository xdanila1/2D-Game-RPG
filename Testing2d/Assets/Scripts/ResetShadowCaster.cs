using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ResetShadowCaster : MonoBehaviour
{
    
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        var objects = FindObjectsOfType<ShadowCaster2D>();
        
        foreach (var item in objects)
        {
            item.enabled = false;
            //yield return new WaitForSeconds(0.1f);
            item.enabled = true;


        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
