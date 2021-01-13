using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GridStructureTests
    {
        GridStructure gridStructure;
        [OneTimeSetUp]
        public void Init()
        {
            gridStructure = new GridStructure(3,100,100);
        }
        #region GridCalculatePositionTests
        [Test]
        public void CalculateGridPositionPasses()
        {
            Vector3 position = new Vector3(0, 0, 0);
            Vector3 returnedPosition = gridStructure.CalculateGridPosition(position);
            Assert.AreEqual(Vector3.zero, returnedPosition);
        }
        [Test]
        public void CalculateGridPositionFails()
        {
            Vector3 position = new Vector3(3.1f, 0, 0);
            Vector3 returnedPosition = gridStructure.CalculateGridPosition(position);
            Assert.AreNotEqual(Vector3.zero, returnedPosition);
        }
        [Test]
        public void CalculateGridPositionFloatPasses()
        {
            Vector3 position = new Vector3(2.9f, 0, 2.9f);
            Vector3 returnedPosition = gridStructure.CalculateGridPosition(position);
            Assert.AreEqual(Vector3.zero, returnedPosition);
        }  
        #endregion

        #region GridPlacementTests
        [Test]
        public void PlaceStructureIn303Passes()
        {
            Vector3 position = new Vector3(3, 0, 3);
            Vector3 returnedPosition = gridStructure.CalculateGridPosition(position);
            GameObject testGameObject = new GameObject();
            gridStructure.PlaceStructureOnGrid(testGameObject, returnedPosition);
            Assert.IsTrue(gridStructure.IsCellTaken(position));
        }
        [Test]
        public void PlaceStructureMINPositionPasses()
        {
            Vector3 position = new Vector3(0, 0, 0);
            Vector3 returnedPosition = gridStructure.CalculateGridPosition(position);
            GameObject testGameObject = new GameObject();
            gridStructure.PlaceStructureOnGrid(testGameObject, returnedPosition);
            Assert.IsTrue(gridStructure.IsCellTaken(position));
        }
        [Test]
        public void PlaceStructureMAXPositionPasses()
        {
            Vector3 position = new Vector3(297, 0, 297);
            Vector3 returnedPosition = gridStructure.CalculateGridPosition(position);
            GameObject testGameObject = new GameObject();
            gridStructure.PlaceStructureOnGrid(testGameObject, returnedPosition);
            Assert.IsTrue(gridStructure.IsCellTaken(position));
        }
        [Test]
        public void PlaceNullStructureFails()
        {
            Vector3 position = new Vector3(3, 0, 3);
            Vector3 returnedPosition = gridStructure.CalculateGridPosition(position);
            GameObject testGameObject = null;
            gridStructure.PlaceStructureOnGrid(testGameObject, returnedPosition);
            Assert.IsFalse(gridStructure.IsCellTaken(position));
        }
        [Test]
        public void PlaceStructureIndexOutOfBoundsExceptionFails()
        {
            Vector3 position = new Vector3(400, 0, 400);
            Vector3 returnedPosition = gridStructure.CalculateGridPosition(position);
            GameObject testGameObject = new GameObject();
            gridStructure.PlaceStructureOnGrid(testGameObject, returnedPosition);
            Assert.Throws<IndexOutOfRangeException>(() => gridStructure.IsCellTaken(position));
        }            [Test]
        public void PlaceStructureNegativeIndexOutOfBoundsExceptionFails()
        {
            Vector3 position = new Vector3(-3, 0, -3);
            Vector3 returnedPosition = gridStructure.CalculateGridPosition(position);
            GameObject testGameObject = new GameObject();
            gridStructure.PlaceStructureOnGrid(testGameObject, returnedPosition);
            Assert.Throws<IndexOutOfRangeException>(() => gridStructure.IsCellTaken(position));
        }        
        #endregion

    }
}
