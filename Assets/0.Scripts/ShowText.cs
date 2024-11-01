using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    [SerializeField] private Text text;
    private Animator anim;

    private void Awake()
    {
        anim = text.GetComponent<Animator>();
    }

    public void Show()
    {
        anim.SetBool("isOn", true);
    }

    public void Hide()
    {
        anim.SetBool("isOn", false);
    }
}
