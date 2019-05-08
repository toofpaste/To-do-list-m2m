
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;
using System.Collections.Generic;
using System;
// using MySql.Data.MySqlClient;

namespace ToDoList.Tests
{
  [TestClass]
  public class ItemTest : IDisposable
  {

    public void Dispose()
    {
      Item.ClearAll();
    }

    public ItemTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=to_do_list_test;";
    }

    [TestMethod]
    public void ItemConstructor_CreatesInstanceOfItem_Item()
    {
      DateTime dd = new DateTime(2011, 6, 10);
      int catId = 0;
      Item newItem = new Item("stuff", dd, catId);
      Assert.AreEqual(typeof(Item), newItem.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      int catId = 0;
      DateTime dd = new DateTime(2011, 6, 10);
      string description = "Walk the dog";
      Item newItem = new Item(description, dd, catId);
      string result = newItem.GetDescription();
      Assert.AreEqual(description, result);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {int catId = 0;
      DateTime dd = new DateTime(2011, 6, 10);
      string description = "walk the dog";
      Item newItem = new Item(description, dd, catId);

      string updatedDescription = "do the dishes";
      newItem.SetDescription(updatedDescription);
      string result = newItem.GetDescription();

      Assert.AreEqual(updatedDescription, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_ItemList()
    {
      List<Item> newList = new List<Item> { };
      List<Item> result = Item.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    // [TestMethod]
    // public void GetAll_ReturnsItems_ItemList()
    // {
    //   int catId = 0;
    //   string description01 = "walk the dog";
    //   string description02 = "wash the dishes";
    //   DateTime dd = new DateTime(2011, 6, 10);
    //   Item newItem1 = new Item(description01, dd, catId);
    //   newItem1.Save();
    //   Item newItem2 = new Item(description02, dd, catId);
    //   newItem2.Save();
    //   List<Item> newList = new List<Item> { newItem1, newItem2 };
    //   List<Item> result = Item.GetAll();
    //   CollectionAssert.AreEqual(newList, result);
    // }

    // [TestMethod]
    // public void GetId_ItemsInstantiateWithAnIdAndGetterReturns_Int()
    // {
    //   string description = "Walk the dog.";
    //   Item newItem = new Item(description);

    //   int result = newItem.GetId();

    //   Assert.AreEqual(1, result);
    // }
    //
    // [TestMethod]
    // public void Find_ReturnsCorrectItemFromDatabase_Item()
    // {
    //   //Arrange
    //   int catId = 0;
    //   DateTime dd = new DateTime(2011, 6, 10);
    //   Item testItem = new Item("Mow the lawn", dd, catId);
    //   testItem.Save();
    //
    //   //Act
    //   Item foundItem = Item.Find(testItem.GetId());
    //
    //   //Assert
    //   Assert.AreEqual(testItem, foundItem);
    // }
    //
    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
    {
      int catId = 0;
      DateTime dd = new DateTime(2011, 6, 10);
      Item firstItem = new Item("Mow the lawn", dd, catId);
      Item secondItem = new Item("Mow the lawn", dd, catId);
      Assert.AreEqual(firstItem, secondItem);
    }
    //
    // [TestMethod]
    // public void Save_SavesToDatabase_ItemList()
    // {
    //   int catId = 0;
    //   DateTime dd = new DateTime(2011, 6, 10);
    //   Item testItem = new Item("Mow the lawn", dd, catId);
    //   testItem.Save();
    //   List<Item> result = Item.GetAll();
    //   List<Item> testList = new List<Item>{testItem};
    //   CollectionAssert.AreEqual(testList, result);
    // }
    //
    // [TestMethod]
    // public void Save_AssignsIdToObject_Id()
    // {
    //   int catId = 0;
    //   DateTime dd = new DateTime(2011, 6, 10);
    //   Item testItem = new Item("Mow the lawn", dd, catId);
    //   testItem.Save();
    //   Item savedItem = Item.GetAll()[0];
    //   int result = savedItem.GetId();
    //   int testId = testItem.GetId();
    //   Assert.AreEqual(testId, result);
    // }
    // [TestMethod]
    // public void Edit_UpdatesItemInDatabase_String()
    // {
    //   //Arrange
    //   int catId = 0;
    //   DateTime dd = new DateTime(2011, 6, 10);
    //   string firstDescription = "Walk the Dog";
    //   Item testItem = new Item(firstDescription, dd, catId);
    //   testItem.Save();
    //   string secondDescription = "Mow the lawn";
    //
    //   //Act
    //   testItem.Edit(secondDescription);
    //   string result = Item.Find(testItem.GetId()).GetDescription();
    //
    //   //Assert
    //   Assert.AreEqual(secondDescription, result);
    // }

    // [TestMethod]
    // public void GetCatigoryId_ReturnsItemParentCategoryId_Int()
    // {
    //   DateTime dd = new DateTime(2011, 6, 10);
    //   Category newCategory = new Category("Home Tasks");
    //   Item newItem = new Item("Walk the dag.", dd, newCategory.GetId());
    //
    //   int result = newItem.GetCategoryId();
    //
    //   Assert.AreEqual(newCategory.GetId(), result);
    // }

  }
}
