using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ToDoList.Models
{
  public class Item
  {
    private string _description;
    private DateTime _dueDate;
    private int _id;
    private int _categoryId;

    public Item (string description, DateTime dueDate, int categoryId, int id = 0)
    {
      _description = description;
      _dueDate = dueDate;
      _id = id;
      _categoryId = categoryId;
    }
    public DateTime GetDate()
    {
      return _dueDate;
    }
    public int GetCategoryId()
    {
      return _categoryId;
    }

    public string GetDescription()
    {
      return _description;
    }
    public void SetDueDate(DateTime dueDate)
  {
    _dueDate = dueDate;
  }

    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }

    public int GetId()
    {
      return _id;
    }

    public static List<Item> GetAll()
    {
      List<Item> allItems = new List<Item> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `items` ORDER BY `dueDate`  ASC;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int itemId = rdr.GetInt32(0);
        string itemDescription = rdr.GetString(1);
        DateTime dueDate = rdr.GetDateTime(2);
        int itemCategoryId = rdr.GetInt32(3);
        Item newItem = new Item(itemDescription, dueDate, itemCategoryId, itemId);
        allItems.Add(newItem);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allItems;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM items;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Item Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `items` WHERE id = @thisId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int itemId = 0;
      string itemDescription = "";
      // while (rdr.Read())
      // {
      rdr.Read();
      itemId = rdr.GetInt32(0);
      itemDescription = rdr.GetString(1);
      DateTime dueDate = rdr.GetDateTime(2);
      int catId = rdr.GetInt32(3);
      Item foundItem = new Item(itemDescription, dueDate, catId, itemId);
      // }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundItem;
    }

    public override bool Equals(System.Object otherItem)
    {
      if (!(otherItem is Item))
      {
        return false;
      }
      else
      {
        Item newItem = (Item) otherItem;
        bool idEquality = (this.GetId() == newItem.GetId());
        bool descriptionEquality = (this.GetDescription() == newItem.GetDescription());
        bool dueDateEquality = (this.GetDate() == newItem.GetDate());
        bool categoryEquality = this.GetCategoryId() == newItem.GetCategoryId();
        return (idEquality && descriptionEquality && categoryEquality);
      }
    }


        public void Edit(string newDescription)
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"UPDATE items SET description = @newDescription WHERE id = @searchId;";
          MySqlParameter searchId = new MySqlParameter();
          searchId.ParameterName = "@searchId";
          searchId.Value = _id;
          cmd.Parameters.Add(searchId);
          MySqlParameter description = new MySqlParameter();
          description.ParameterName = "@newDescription";
          description.Value = newDescription;
          cmd.Parameters.Add(description);
          cmd.ExecuteNonQuery();
          _description = newDescription; // <--- This line is new!
          conn.Close();
          if (conn != null)
          {
            conn.Dispose();
          }
        }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO items (description, dueDate, category_id) VALUES (@ItemDescription,  @ItemDueDate, @CategoryId);";
      MySqlParameter description = new MySqlParameter();
      description.ParameterName = "@ItemDescription";
      description.Value = this._description;
      MySqlParameter dueDate = new MySqlParameter();
      MySqlParameter category_id = new MySqlParameter();
      category_id.ParameterName = "@CategoryId";
      dueDate.ParameterName = "@ItemDueDate";
      category_id.Value = this._categoryId;
      dueDate.Value = this._dueDate;
      cmd.Parameters.Add(category_id);
      cmd.Parameters.Add(description);
      cmd.Parameters.Add(dueDate);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      _categoryId = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }


  }
}
