using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FallingObject : MonoBehaviour
{
    public float fallingSpeed = 1;
    public float rotationSpeed = 1;
    public float maxDistance = 50f;
    
    private float _distanceTravelled;

    private void Start()
    {
        transform.Rotate(new Vector3(0, 0,Random.Range(0, 360)));
    }

    private void Update()
    {
        var distance = fallingSpeed * Time.deltaTime;
        
        transform.position -= new Vector3(0 ,distance, 0);
        _distanceTravelled += distance;
        transform.Rotate(new Vector3(0, 0,rotationSpeed*Time.deltaTime));
        
        if (_distanceTravelled > maxDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this);
    }
}
