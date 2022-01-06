using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.Architecture.Core.ProjectAggregate;
using Ardalis.Specification;

namespace Clean.Architecture.Wpf.ViewModels;

public class ProjectsWithItemsSpec : Specification<Project>
{
  public ProjectsWithItemsSpec()
  {
    Query.Include(proj => proj.Items);
  }
}
