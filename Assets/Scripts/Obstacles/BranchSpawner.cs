using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchSpawner : MonoBehaviour
{
    public float spawnInterval = 2;
    public GameObject branchPrefab;
    
    private float _lastSpawnTime;

    private void Start()
    {
        var sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.enabled = false;
        }
    }

    void spawnBranch()
    {
        Instantiate(branchPrefab, transform.position, Quaternion.identity);
    } 
        
    private void Update()
    {
        if (Time.time - _lastSpawnTime > spawnInterval)
        {
            _lastSpawnTime = Time.time;
            spawnBranch();
        }
    }
}
