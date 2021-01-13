using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellTests
{
    [Test]
    public void CellSetGameObjectPasses()
    {
        Cell cell = new Cell();
        cell.SetStructure(new GameObject());
        Assert.IsTrue(cell.IsTaken);
    }    
    [Test]
    public void CellSetGameObjectFails()
    {
        Cell cell = new Cell();
        cell.SetStructure(null);
        Assert.IsFalse(cell.IsTaken);
    }
}
