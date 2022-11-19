using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchSpawner : MonoBehaviour
{
    public float spawnInterval = 2;
    public GameObject branchPrefab;
    public Camera cam;
    
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
        GameObject branch = Instantiate(branchPrefab, transform.position, Quaternion.identity);
        branch.GetComponent<FallingObject>().Initialize(cam);
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
