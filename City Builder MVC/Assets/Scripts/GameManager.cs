using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlacementManager placementManager;
    [SerializeField] InputManager InputManager;

    private GridStructure grid;
    [SerializeField] int cellSize = 3;

    void Start()
    {
        grid = new GridStructure(cellSize);
        InputManager.AddListenerOnPointerDownEvent(HandleInput);
    }

    private void HandleInput(Vector3 position)
    {
        placementManager.CreateBuilding(grid.CalculateGridPosition(position));
    }

    void Update()
    {
        
    }
}
