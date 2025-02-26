using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected float speed = 0.1f;
    [SerializeField] protected Vector3 targetPos ;


    private void FixedUpdate()
    {
        this.GetTargetPos();
        this.Moving();
        this.LookAtTarget();
    }

    protected virtual void GetTargetPos()
    {
        this.targetPos = InputManager.instance.GetMousePos();
        this.targetPos.z = 0;
    }
    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPos, speed);
        transform.parent.position = newPos;
    }
    protected virtual void LookAtTarget()
    {
        Vector3 direction = targetPos - transform.parent.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float smoothAngle = Mathf.LerpAngle(transform.parent.eulerAngles.z, angle, Time.deltaTime * 10f);
        transform.parent.rotation = Quaternion.Euler(0, 0, smoothAngle);
    }
}
