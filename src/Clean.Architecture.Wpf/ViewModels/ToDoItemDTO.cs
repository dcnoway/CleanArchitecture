using Clean.Architecture.Core.ProjectAggregate;
using System.ComponentModel;

namespace Clean.Architecture.Wpf.ViewModels;

public class ToDoItemDTO : INotifyPropertyChanged
{
  public event PropertyChangedEventHandler? PropertyChanged;
  private void OnPropertyChanged(string prop)
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
  }

  private int _Id = -1;
  public int Id
  {
    get { return _Id; }
    set
    {
      if (_Id != value)
      {
        _Id = value;
        OnPropertyChanged(nameof(Id));
      }
    }
  }

  private string? _Title;
  public string? Title
  {
    get => _Title;
    set
    {
      if (_Title != value)
      {
        _Title = value;
        OnPropertyChanged(nameof(Title));
      }
    }
  }

  private string? _Description;
  public string? Description
  {
    get => _Description;
    set
    {
      if (value != _Description)
      {
        _Description = value;
        OnPropertyChanged(nameof(Description));
      }
    }
  }

  private bool _IsDone = false;
  public bool IsDone
  {
    get => _IsDone;
    set
    {
      if (value != _IsDone)
      {
        _IsDone = value;
        OnPropertyChanged(nameof(IsDone));
      }
    }
  }

  public static ToDoItemDTO FromToDoItem(Core.ProjectAggregate.ToDoItem item)
  {
    return new ToDoItemDTO()
    {
      Id = item.Id,
      Title = item.Title,
      Description = item.Description,
      IsDone = item.IsDone
    };
  }

  public override string ToString()
  {
    if (_Title == null) return "N/A";
    return _Title;
  }
}
