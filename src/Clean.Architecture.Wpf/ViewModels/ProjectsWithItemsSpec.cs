using Ardalis.Specification;
using Clean.Architecture.Core.ProjectAggregate;
//using System;
//using System.Linq;

namespace Clean.Architecture.Wpf.ViewModels;

public class ProjectsWithItemsSpec : Specification<Project>
{
  public ProjectsWithItemsSpec()
  {
    Query.Include(proj => proj.Items);
  }
}
