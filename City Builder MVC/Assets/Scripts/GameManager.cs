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
    [SerializeField] int gridRows;
    [SerializeField] int gridColumns;

    void Start()
    {
        grid = new GridStructure(cellSize,gridRows,gridColumns);
        InputManager.AddListenerOnPointerDownEvent(HandleInput);
    }

    private void HandleInput(Vector3 position)
    {
        Vector3 gridPosition = grid.CalculateGridPosition(position);
        if (!grid.IsCellTaken(gridPosition))
        {
            placementManager.CreateStructure(gridPosition, grid);
            
        }
    }

    void Update()
    {
        
    }
}
