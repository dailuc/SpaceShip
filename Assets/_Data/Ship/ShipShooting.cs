using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected Transform bulletPrefab;

    private void Update()
    {
        this.IsShooting();
        this.Shooting();
    }
    protected void Shooting()
    {
        if (!isShooting) return;

        Vector3 spawnPos = transform.parent.position;
        Quaternion rotation = transform.parent.rotation;
        Instantiate(this.bulletPrefab,spawnPos,rotation);
    }
    protected void IsShooting()
    {
        float index = InputManager.instance.GetMouseDown();
        if(index == 1)
        {
            isShooting=true;
        }
        if(index == 0)
        {
            isShooting=false;
        }
    }
}
