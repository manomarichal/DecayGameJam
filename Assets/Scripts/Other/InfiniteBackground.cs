using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    public GameObject cam;
    public Parralax parralax;

    private float _startPos;
    private float _lenght;
    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position.x;
        _lenght = GetComponent<SpriteRenderer>().bounds.size.x * transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        

        transform.position = new Vector3(_startPos, transform.position.y, transform.position.z);
    }
}
