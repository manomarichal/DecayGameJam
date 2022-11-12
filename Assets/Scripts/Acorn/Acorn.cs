using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    public float velocity;
    private Camera _camera;
    private int _direction = 1;
    private bool _isInitialized = false;
    public void Initialize(int direction, Camera mainCamera)
    {
        _direction = direction;
        _camera = mainCamera;
        _isInitialized = true;
    }
    
    public void SetDirection(int direction)
    {
    }

    private void Update()
    {
        if (!_isInitialized) return;
        
        transform.position = new Vector3(transform.position.x + velocity * _direction, transform.position.y,
            transform.position.z);
        
        // Destroy object if it is out of view
        Vector3 viewPos = _camera.WorldToViewportPoint(transform.position);
        if (!(viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0))
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
