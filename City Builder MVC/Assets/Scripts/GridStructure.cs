﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridStructure
{
    private int cellSize;
    private int rows, columns;
    Cell[,] grid;

    public GridStructure(int cellSize, int rows, int columns)
    {
        this.cellSize = cellSize;
        this.rows = rows;
        this.columns = columns;
        grid = new Cell[this.rows, this.columns];
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                grid[row, col] = new Cell();
            }
        }
    }

    public Vector3 CalculateGridPosition(Vector3 inputPosition)
    {
        int x = Mathf.FloorToInt((float)inputPosition.x / cellSize);
        int z = Mathf.FloorToInt((float)inputPosition.z / cellSize);
        return new Vector3(x * cellSize, 0, z * cellSize);
    }

    private Vector2Int CalculateGridIndex(Vector3 gridPosition)
    {
        return new Vector2Int((int)gridPosition.x / cellSize, (int)(gridPosition.z / cellSize));
    }

    public bool IsCellTaken(Vector3 gridPosition)
    {
        Vector2Int cellIndex = CalculateGridIndex(gridPosition);
        if (IsIndexValid(cellIndex))
            return grid[cellIndex.y, cellIndex.x].IsTaken;

        throw new IndexOutOfRangeException("No index " + cellIndex + "in grid.");
    }

    public void PlaceStructureOnGrid(GameObject structure, Vector3 gridPosition)
    {
        Vector2Int cellIndex = CalculateGridIndex(gridPosition);
        if (IsIndexValid(cellIndex))
            grid[cellIndex.y, cellIndex.x].SetStructure(structure);
    }

    private bool IsIndexValid(Vector2Int cellIndex)
    {
        if ((cellIndex.x >= 0 && cellIndex.x < grid.GetLength(1)) && (cellIndex.y >= 0 && cellIndex.y < grid.GetLength(0)))
            return true;
        return false;
    }
}
