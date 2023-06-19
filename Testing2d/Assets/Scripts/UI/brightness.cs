using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using TMPro;

public class brightness : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI AmmountUI;
    private Light2D _light;
    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponent<Light2D>();
        AmmountUI.text = "" + _light.intensity;
    }

    public void Rase()
    {
        _light.intensity += 0.1f;
        AmmountUI.text = ""+_light.intensity;
    }
    public void Decrease()
    {
        _light.intensity -= 0.1f;
        AmmountUI.text = "" + _light.intensity;
    }
    public void SlightlyRase()
    {
        _light.intensity += 0.01f;
        AmmountUI.text = "" + _light.intensity;
    }
    public void SlightlyDecrease()
    {
        _light.intensity -= 0.01f;
        AmmountUI.text = "" + _light.intensity;
    }

}
