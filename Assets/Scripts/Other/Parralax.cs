using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    public GameObject cam;
    public float parralaxScale;

    private float _lenght;
    private float _startPos;
    // Start is called before the first frame update
    
    void Start()
    {
        _lenght = GetComponent<SpriteRenderer>().bounds.size.x * transform.localScale.x;
        _startPos = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var distance = (cam.transform.position.x * parralaxScale);

        transform.position = new Vector3(_startPos - distance, transform.position.y, transform.position.z);
    
    }
}
