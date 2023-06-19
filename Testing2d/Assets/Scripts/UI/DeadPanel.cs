using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeadPanel : MonoBehaviour
{
    [SerializeField]private GameObject _child; // dead panel UI
    private Animator _anim;

    [SerializeField] private TextMeshProUGUI _numGold;
    [SerializeField] private TextMeshProUGUI _Time;

    private void Start()
    {
        _anim = _child.GetComponent<Animator>();

        NPC.OnDead += PlayAnim;
    }
    private void OnDisable()
    {
        NPC.OnDead -= PlayAnim;
    }
    private void PlayAnim(int score)
    {
        Time.timeScale = 1f;
        _Time.text = Mathf.FloorToInt( Time.time/60f) +" : "+Time.time%60f ;
        _numGold.text = score+"";
        _child.SetActive(true);
        _anim.Play("New Animation");
    }
}
