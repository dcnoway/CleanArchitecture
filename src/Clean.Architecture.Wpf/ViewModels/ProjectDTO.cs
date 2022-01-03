using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
namespace Clean.Architecture.Wpf.ViewModels;

public class ProjectDTO : INotifyPropertyChanged
{
  public event PropertyChangedEventHandler? PropertyChanged;
  public void OnPropertyChanged(string prop)
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
  }

  private int _Id =-1;
  public int Id
  {
    get => _Id;
    set
    {
      if (value != _Id)
      {
        _Id = value;
        OnPropertyChanged(nameof(Id));
      }
    }
  }

  private string? _Name;
  public string? Name 
  { 
    get =>_Name;
    set
    {
      if(value != _Name)
      {
        _Name = value;
        OnPropertyChanged(nameof(Name));
      }
    }
  }

  //private List<ToDoItem> _Items = new();
  private ObservableCollection<ToDoItemDTO> _items = new();
  public ObservableCollection<ToDoItemDTO> Items
  {
    get => _items;
    set
    {
      if(value != _items)
      {
        _items=value;
        OnPropertyChanged(nameof(Items));
      }
    }
  }

  public override string ToString()
  {
    if (_Name == null) return "N/A";
    return _Name;
  }
}
