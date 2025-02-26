using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance { get; private set; }

    [SerializeField] private Vector3 mouseWorldPos;

    [SerializeField] private float onFiring;

    [SerializeField] private Camera mainCamera;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void FixedUpdate()
    {
        this.GetMousePos();
        this.GetMouseDown();
    }
    public virtual Vector3 GetMousePos()
    {
        if(mainCamera == null)
        {
            mainCamera = Camera.main;
            if (mainCamera == null)
            {
                Debug.Log("camera not found !");
                return Vector3.zero;
            }
        }

        this.mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        return mouseWorldPos;
    }
    public virtual float GetMouseDown() {
        this.onFiring = Input.GetAxis("Fire1");
        return this.onFiring;
    }
}
