using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    [SerializeField] GameObject structurePrefab;
    [SerializeField] Transform ground;

    public void CreateStructure(Vector3 gridPosition, GridStructure grid)
    {
        GameObject newStructure = Instantiate(structurePrefab, ground.position + gridPosition, Quaternion.identity);
        grid.PlaceStructureOnGrid(newStructure, gridPosition);
        newStructure.transform.parent = transform;
    }
}
