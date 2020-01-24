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
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Remove_RemovesAValue_ExpectFirstOccurenceRemoved()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            list.Add(5);
            //Act
            list.Remove(5);
            //Assert
            int actual = list[0];
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
            CustomList<int> expected = new CustomList<int>();
            expected.Add(5);
            expected.Add(6);
            expected.Add(7);
            //Act
            list.Remove(8);
            //Assert
            Assert.AreEqual(expected.ToString(), list.ToString());
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
        public void AdditionOperator_AddingEmptyList_ExpectOutputToMatchFirstList()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list1.Add(5);
            list1.Add(6);
            //Act
            CustomList<int> actual = list1 + list2;
            //Assert
            Assert.AreEqual(list1, actual);
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
        public void SubtractionOperator_SubtractingFullList_ExpectSimilarValuesToBeRemovedFromList1()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list2.Add(1);
            list2.Add(6);
            list2.Add(3);
            //Act
            list1 = list1 - list2;
            //Assert
            Assert.AreEqual(2, list1[0]);
        }

        [TestMethod]
        public void SubtractionOperator_SubtractingEmptyList_ExpectsOutputListToBeTheSameAsFirstList()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            CustomList<int> expected = list1;
            //Act
            list1 = list1 - list2;
            //Assert
            Assert.AreEqual(expected, list1);
        }

        [TestMethod]
        public void SubtractionOperator_SubtractingFromEmptyList_ExpectsOutputListToBeTheSameAsFirstList()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list2.Add(1);
            list2.Add(2);
            list2.Add(3);
            CustomList<int> expected = list1;
            //Act
            list1 = list1 - list2;
            //Assert
            Assert.AreEqual(expected, list1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
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

        [TestMethod]
        public void Zip_ZipTwoFullLists_ExpectOutputListToSwitchOffBetweenFirstAndSecondList()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            CustomList<int> expected = new CustomList<int>();
            list.Add(1);
            list.Add(3);
            list.Add(5);
            list2.Add(2);
            list2.Add(4);
            list2.Add(6);
            expected.Add(1);
            expected.Add(2);
            expected.Add(3);
            expected.Add(4);
            expected.Add(5);
            expected.Add(6);
            //Act
            CustomList<int> actual = list.Zip(list2);
            //Assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void Zip_ZipOneEmptyAndOneFullList_ExpectOutputListToMatchListOne()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            CustomList<int> expected = new CustomList<int>();
            list.Add(1);
            list.Add(3);
            list.Add(5);
            expected.Add(1);
            expected.Add(3);
            expected.Add(5);
            //Act
            CustomList<int> actual = list.Zip(list2);
            //Assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void Zip_ZipOneLargeListAndOneSmall_ExpectOutputListToSwitchOffBetweenFirstAndSecondList()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            CustomList<int> expected = new CustomList<int>();
            list.Add(1);
            list.Add(3);
            list.Add(5);
            list2.Add(2);
            list2.Add(6);
            expected.Add(1);
            expected.Add(2);
            expected.Add(3);
            expected.Add(6);
            expected.Add(5);
            //Act
            CustomList<int> actual = list.Zip(list2);
            //Assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void Sort_BubbleSortTwoFullArrays_ExpectArrayToBeSortedInAscendingOrder()
        {
            //Arrange
            CustomList<string> list = new CustomList<string>();
            CustomList<string> expected = new CustomList<string>();
            list.Add("a");
            list.Add("t");
            list.Add("b");
            list.Add("z");
            expected.Add("a");
            expected.Add("b");
            expected.Add("t");
            expected.Add("z");
            //Act
            list.Sort();
            //Assert
            Assert.AreEqual(expected.ToString(), list.ToString());
        }

        [TestMethod]
        public void Sort_BubbleSortSingleValue_ExpectArrayToBeSortedInAscendingOrder()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            CustomList<int> expected = new CustomList<int>();
            list.Add(6);
            expected.Add(6);
            //Act
            list.Sort();
            //Assert
            Assert.AreEqual(expected.ToString(), list.ToString());
        }

        [TestMethod]
        public void Sort_BubbleSortPreSortedList_ExpectArrayToBeSortedInAscendingOrder()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            CustomList<int> expected = new CustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            expected.Add(1);
            expected.Add(2);
            expected.Add(3);
            expected.Add(4);
            //Act
            list.Sort();
            //Assert
            Assert.AreEqual(expected.ToString(), list.ToString());
        }
    }
}
