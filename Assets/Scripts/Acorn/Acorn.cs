using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    public float velocity;
    public float maxDistance = 50f;
 
    private int _direction = 1;
    private bool _isInitialized = false;
    private float _distanceTravelled;
    
    public void Initialize(int direction, Camera mainCamera)
    {
        _direction = direction;
        _isInitialized = true;
    }
    

    private void Update()
    {
        if (!_isInitialized) return;

        var distance = velocity * _direction * Time.deltaTime;
        
        transform.position += new Vector3(distance ,0, 0);
        _distanceTravelled += distance;

        if (_distanceTravelled > maxDistance)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
