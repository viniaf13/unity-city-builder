using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    [SerializeField] LayerMask mouseInputMask;
    //[SerializeField] GameObject buildingPrefab;
    //[SerializeField] int cellSize = 3;

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
            //Vector3 gridPosition = CalculateGridPosition(mousePosition);
            //CreateBuilding(gridPosition);
        }
    }

    /*private Vector3 CalculateGridPosition(Vector3 inputPosition)
    {
        int x = Mathf.FloorToInt((float)inputPosition.x / cellSize);
        int z = Mathf.FloorToInt((float)inputPosition.z / cellSize);
        return new Vector3(x*cellSize, 0, z*cellSize);
    }

    private void CreateBuilding(Vector3 gridPosition)
    {
        GameObject building = Instantiate(buildingPrefab, gridPosition, Quaternion.identity) as GameObject;
        //building.transform.parent
    }*/
}
