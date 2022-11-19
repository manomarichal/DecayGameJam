using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnPlayerAttackHit : MonoBehaviour
{
    public AK.Wwise.Event deathSound;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Attack"))
        {
            deathSound.Post(gameObject);
            
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }
}
