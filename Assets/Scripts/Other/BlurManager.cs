using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BlurManager : MonoBehaviour
{
    public Volume vol;

    public bool enable;

    private DepthOfField _de;

    private void Start()
    {
        _de = (DepthOfField)vol.profile.components[0];
        
    }

    private void Update()
    {
        var components = vol.profile.components;
        for (int i = 0; i < vol.profile.components.Count; i++)        {
            if(vol.profile.components[i].name == "DepthOfField(Clone)")
            {
                _de.focalLength = new ClampedFloatParameter(_de.focalLength.value + 0.01f, _de.focalLength.min, _de.focalLength.max,true);
            }
        }
    }
}
