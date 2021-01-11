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
            gridStructure = new GridStructure(3);
        }

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

    }
}
