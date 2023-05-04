using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    
    public void ExitToGame()
    {
        Debug.Log("exit");
        Application.Quit();    
    }
    public void HideObject(GameObject obj)
    {
        obj.SetActive(false);

    }
    public void ShowObject(GameObject obj)
    {
        obj.SetActive(true);
    }
}
