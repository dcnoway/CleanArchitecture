using Clean.Architecture.Core.ProjectAggregate;
using System.ComponentModel;

namespace Clean.Architecture.Wpf.ViewModels;

public class ToDoItemProxy : INotifyPropertyChanged
{
  protected ToDoItem _item;
  public ToDoItem GetToDoItem() => _item;

  #region constructor & factory method
  public ToDoItemProxy(ToDoItem item)
  {
    _item = item;
  }
  public static ToDoItemProxy FromToDoItem(ToDoItem item)
  {
    return new ToDoItemProxy(item);
  }
  #endregion

  #region changed event
  public event PropertyChangedEventHandler? PropertyChanged;
  private void OnPropertyChanged(string prop)
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
  }
  #endregion

  #region proxyed properties and methods
  public int Id
  {
    get { return _item.Id; }
    set
    {
      if (_item.Id != value)
      {
        _item.Id = value;
        OnPropertyChanged(nameof(Id));
      }
    }
  }

  public string Title
  {
    get => _item.Title;
    set
    {
      if (_item.Title != value)
      {
        _item.Title = value;
        OnPropertyChanged(nameof(Title));
      }
    }
  }

  public string Description
  {
    get => _item.Description;
    set
    {
      if (value != _item.Description)
      {
        _item.Description = value;
        OnPropertyChanged(nameof(Description));
      }
    }
  }

  public bool IsDone
  {
    get => _item.IsDone;
  }


  public void MarkComplete()
  {
    _item.MarkComplete();
  }
  public override string ToString()
  {
    return _item.ToString();
  }
  #endregion
}
