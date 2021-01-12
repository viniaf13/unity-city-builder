using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    [SerializeField] GameObject buildingPrefab;
    [SerializeField] Transform ground;

    public void CreateBuilding(Vector3 gridPosition)
    {
        GameObject building = Instantiate(buildingPrefab, ground.position + gridPosition, Quaternion.identity) as GameObject;
        building.transform.parent = transform.parent;
    }
}
