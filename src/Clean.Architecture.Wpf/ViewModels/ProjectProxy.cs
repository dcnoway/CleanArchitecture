using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Clean.Architecture.Core.ProjectAggregate;
namespace Clean.Architecture.Wpf.ViewModels;

public class ProjectProxy : INotifyPropertyChanged
{
  protected Project _project;
  protected ObservableCollection<ToDoItemProxy> _items = new();
  public ObservableCollection<ToDoItemProxy> Items => _items;

  public ProjectProxy(Project proj)
  {
    _project = proj;
    foreach(ToDoItem item in proj.Items)
    {
      ToDoItemProxy itemProxy = new ToDoItemProxy(item);
      _items.Add(itemProxy);
    }
  }

  public event PropertyChangedEventHandler? PropertyChanged;
  public void OnPropertyChanged(string prop)
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
  }

  public int Id
  {
    get => _project.Id;
    set
    {
      if (value != _project.Id)
      {
        _project.Id = value;
        OnPropertyChanged(nameof(Id));
      }
    }
  }

  public string Name 
  { 
    get =>_project.Name;
  }

  public ProjectStatus Status
  {
    get => _project.Status;
  }
  
  public void AddItem(ToDoItemProxy newItem)
  {
    _project.AddItem(newItem.GetToDoItem());
    //TODO: Add NotifyCollectionChanged
  }
  public void UpdateNamw(string newNamw)
  {
    _project.UpdateName(newNamw);
  }
  public override string ToString()
  {
    if (_project.Name == null) return "N/A";
    return _project.Name;
  }
}
