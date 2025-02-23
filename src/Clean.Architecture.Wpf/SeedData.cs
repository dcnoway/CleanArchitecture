﻿using Clean.Architecture.Core.ProjectAggregate;
using Clean.Architecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using Clean.Architecture.Wpf.ViewModels;

namespace Clean.Architecture.Wpf;

public static class SeedData
{
  public static readonly Project TestProject1 = new Project("Test Project");
  public static readonly ToDoItem ToDoItem1 = new ToDoItem
  {
    Title = "Get Sample Working",
    Description = "Try to get the sample to build."
  };
  public static readonly ToDoItem ToDoItem2 = new ToDoItem
  {
    Title = "Review Solution",
    Description = "Review the different projects in the solution and how they relate to one another."
  };
  public static readonly ToDoItem ToDoItem3 = new ToDoItem
  {
    Title = "Run and Review Tests",
    Description = "Make sure all the tests run and review what they are doing."
  };

  public static void Initialize(AppDbContext dbContext)
  {
    // Look for any TODO items.
    //dbContext.ToDoItems.AnyAsync().GetAwaiter().GetResult();
    if (dbContext.ToDoItems.AnyAsync().GetAwaiter().GetResult())
    {
      return;   // DB has been seeded
    }

    PopulateTestData(dbContext);
  }


  public static void PopulateTestData(AppDbContext dbContext)
  {
    foreach (var item in dbContext.Projects)
    {
      dbContext.Remove(item);
    }
    foreach (var item in dbContext.ToDoItems)
    {
      dbContext.Remove(item);
    }
    dbContext.SaveChanges();

    TestProject1.AddItem(ToDoItem1);
    TestProject1.AddItem(ToDoItem2);
    TestProject1.AddItem(ToDoItem3);
    dbContext.Projects.Add(TestProject1);

    dbContext.SaveChanges();
  }
}
