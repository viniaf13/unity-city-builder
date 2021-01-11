using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public LayerMask mouseInputMask;
    void Start()
    {
        
    }
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
            GetPointClicked();
        }
    }

    private void GetPointClicked()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, mouseInputMask))
        {
            Vector3 position = hit.point - transform.position;
            Debug.Log(position);
        }
    }
}
