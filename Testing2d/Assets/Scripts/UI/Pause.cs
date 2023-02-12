using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PanelPause;
    
    public void Paused()
    {
        PanelPause.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        PanelPause.SetActive(false);
        Time.timeScale = 1f;
    }
}
