using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AK.Wwise.Event music;
    public AK.Wwise.State state;

    private void Start()
    {
        music.Post(gameObject);
        state.SetValue();
    }
}
