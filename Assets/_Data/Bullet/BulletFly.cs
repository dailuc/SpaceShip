using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 10f;
    [SerializeField] protected Vector3 direction = Vector3.right;

    private void FixedUpdate()
    {
        Fly();
    }
    protected virtual void Fly()
    {
        transform.parent.Translate(this.direction*moveSpeed*Time.deltaTime);
    }
}
