using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    [SerializeField] LayerMask mouseInputMask;

    private Action<Vector3> OnPointerDownHandler;

    void Update()
    {
        GetPlayerInput();
    }

    public void GetPlayerInput()
    {
        //TODO: Compatible with other devices
        //If left button is pressed and it is not on UI
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            CalculateInputPosition();
        }
    }

    private void CalculateInputPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, mouseInputMask))
        {
            Vector3 mousePosition = hit.point - transform.position;
            OnPointerDownHandler?.Invoke(mousePosition);
        }
    }

    public void AddListenerOnPointerDownEvent(Action<Vector3> listener)
    {
        OnPointerDownHandler += listener;
    }    
    public void RemoveListenerOnPointerDownEvent(Action<Vector3> listener)
    {
        OnPointerDownHandler -= listener;
    }
}
