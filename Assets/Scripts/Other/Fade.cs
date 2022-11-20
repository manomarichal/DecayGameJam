using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public Camera cam;
    
    private SpriteRenderer _sr;
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
        _sr.enabled = true;
    }

    public void FadeIn()
    {
        _anim.Play("FadeIn");
    }
    
    public void FadeOut()
    {
        _anim.Play("FadeOut");
    }
}
