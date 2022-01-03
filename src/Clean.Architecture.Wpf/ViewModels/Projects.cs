using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Clean.Architecture.Wpf;

namespace Clean.Architecture.Wpf.ViewModels;

class Projects : ObservableCollection<ProjectDTO>
{
  public Projects():base()
  {
    ProjectDTO prj = new();
    prj.Id = SeedData.TestProject1.Id;
    prj.Name = SeedData.TestProject1.Name;
    ToDoItemDTO item1 = ToDoItemDTO.FromToDoItem(SeedData.ToDoItem1);
    ToDoItemDTO item2 = ToDoItemDTO.FromToDoItem(SeedData.ToDoItem2);
    ToDoItemDTO item3 = ToDoItemDTO.FromToDoItem(SeedData.ToDoItem3);
    prj.Items.Add(item1);
    prj.Items.Add(item2);
    prj.Items.Add(item3);
    this.Add(prj);
  }
}
