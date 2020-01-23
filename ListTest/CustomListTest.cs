using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using List;

namespace ListTest
{
    [TestClass]
    public class CustomListTest
    {
        [TestMethod]
        public void Add_ParameterIsAdded_ExpectValuePlaceAtZeroIndex()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            //Act
            list.Add(5);
            //Assert
            Assert.AreEqual(5, list[0]);
        }

        [TestMethod]
        public void Add_ParameterIsAdded_ExpectCountIsIncreasedByOne()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            //Act
            list.Add(5);
            //Assert
            Assert.AreEqual(1, list.Count);
        }
        [TestMethod]

        public void Add_ParameterIsAdded_ExpectCapacityIncreases()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            //Act
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            //Assert
            Assert.AreEqual(8, list.Capacity);
        }
        [TestMethod]
        public void Add_ParameterIsAdded_ExpectPreviousIndexesUnchanged()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            //Act
            list.Add(5);
            list.Add(6);
            //Assert
            Assert.AreEqual(5, list[0]);
        }

        //Remove

        [TestMethod]
        public void Remove_RemovesAValue_ExpectFirstOccurenceRemoved()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            list.Add(5);
            //Act
            list.Remove(5);
            //Assert
            Assert.AreEqual(0, list[0]);
        }
        [TestMethod]
        public void Remove_RemovesAValue_ExpectCountDecreasedByOne()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            list.Add(5);
            //Act
            list.Remove(5);
            //Assert
            Assert.AreEqual(0, list.Count);
        }
        [TestMethod]
        public void Remove_RemovesAValue_ExpectValuesAtIndexesGreaterThanRemovedToShiftOneLess()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            //Act
            list.Remove(6);
            //Assert
            Assert.AreEqual(7, list[1]);
        }

        [TestMethod]
        public void Remove_RemovesAValue_ExpectValuesAtIndexesLessThanRemovedRemainStationary()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            //Act
            list.Remove(6);
            //Assert
            Assert.AreEqual(5, list[0]);
        }

        [TestMethod]
        public void Remove_RemovesAValueInLastIndex_ExpectLastIndexCleared()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            //Act
            list.Remove(8);
            //Assert
            Assert.AreEqual(0, list[3]);
        }

        [TestMethod]
        public void Remove_RemovesAValue_ExpectRemoveReturnsTrue()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            //Act
            bool actual = list.Remove(6);
            //Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void Remove_ValueDoesntExistInList_ExpectNoValueRemoved()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            list.Add(5);
            //Act
            list.Remove(9);
            //Assert
            Assert.AreEqual(5, list[0]);
        }

        [TestMethod]
        public void Remove_ValueDoesntExistInList_ExpectCountRemainsTheSame()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            list.Add(5);
            //Act
            list.Remove(9);
            //Assert
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void Remove_ValueDoesntExistInList_ExpectRemoveReturnsFalse()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            list.Add(5);
            //Act
            bool actual = list.Remove(9);
            //Assert
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void AdditionOperator_AddingTwoCustomLists_ExpectSecondStringAddedToEndOfFirst()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list1.Add(5);
            list1.Add(6);
            list2.Add(7);
            list2.Add(8);
            //Act
            list1 = list1 + list2;
            //Assert
            Assert.AreEqual(7, list1[2]);
        }

        [TestMethod]
        public void AdditionOperator_AddingEmptyList_ExpectSecondStringAddedToEndOfFirst()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list1.Add(5);
            list1.Add(6);
            //Act
            list1 = list1 + list2;
            //Assert
            Assert.AreEqual(0, list1[2]);
        }

        [TestMethod]
        public void AdditionOperator_AddingToEmptyList_ExpectSecondStringAddedToEndOfFirst()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list2.Add(5);
            list2.Add(6);
            //Act
            list1 = list1 + list2;
            //Assert
            Assert.AreEqual(6, list1[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_UnaccessibleIndexInput_ExpectThrowIndexOutOfRangeException()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            list1.Add(5);
            list1.Add(6);
            //Act
            int actual = list1[-1];
        }

        [TestMethod]
        public void ToString_ConvertingFullList_ExpectListToBePrintedAsString()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            list.Add(5);
            list.Add(6);
            //Act
            string actual = list.ToString();
            //Assert
            Assert.AreEqual("56", actual);
        }

        [TestMethod]
        public void ToString_ConvertingEmptyList_ExpectListToBePrintedAsString()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            //Act
            string actual = list.ToString();
            //Assert
            Assert.AreEqual("", actual);
        }
    }
}
