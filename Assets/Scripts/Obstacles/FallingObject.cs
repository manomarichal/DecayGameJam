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
    
    public AK.Wwise.Event hitFloor;

    private Camera _cam;
    private float _distanceTravelled;

    private void Start()
    {
        transform.Rotate(new Vector3(0, 0,Random.Range(0, 360)));
    }

    public void Initialize(Camera cam)
    {
        _cam = cam;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            Vector3 viewPos = _cam.WorldToViewportPoint(transform.position);
            if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
            {
                hitFloor.Post(gameObject);
            }
            Destroy(gameObject);
        }
    }
}
