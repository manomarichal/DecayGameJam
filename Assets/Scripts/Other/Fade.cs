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
        _sr.enabled = false;
    }

    public void FadeIn()
    {
        _sr.enabled = true;
        _anim.Play("FadeIn");
    }
    
    public void FadeOut()
    {
        _sr.enabled = true;
        _anim.Play("FadeOut");
    }
}
