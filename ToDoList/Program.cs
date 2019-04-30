using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ToDoList
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = new WebHostBuilder()
        .UseKestrel()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseIISIntegration()
        .UseStartup<Startup>()
        .Build();

      host.Run();
    }
  }
}

// using System;
// using System.Collections.Generic;
//
// namespace ToDoList
// {
//   class MainClass
//   {
//     public static void Main()
//     {
//       Console.WriteLine("Welcome to the To Do List");
//       Item newItem = new Item("");
//
//       int x = 0;
//
//       while(x ==0)
//       {
//         Console.WriteLine("Would you like to add an item to your list or view your list? (Add/View)");
//         string Ans = Console.ReadLine().ToLower();
//         if (Ans == "add")
//         {
//           Console.WriteLine("Enter in your To Do Item");
//           string newDescription = Console.ReadLine();
//           new Item(newDescription);
//         }
//         else
//         {
//           Console.WriteLine("line 31",Ans);
//           List<Item> newList = Item.GetAll();
//
//           foreach (Item element in newList)
//           {
//             Console.WriteLine(element.GetDescription());
//           }
//           x = 1;
//           break;
//         }
//       }
//
//     }
//   }
// }
