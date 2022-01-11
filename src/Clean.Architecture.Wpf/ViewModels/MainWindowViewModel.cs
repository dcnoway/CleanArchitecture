using Clean.Architecture.Core.ProjectAggregate;
using Clean.Architecture.Infrastructure.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Clean.Architecture.Wpf.ViewModels;

internal class MainWindowViewModel : INotifyPropertyChanged
{
  protected ObservableCollection<ProjectProxy> _projects = new();
  public ObservableCollection<ProjectProxy> Projects { get => _projects; }

  //public static RoutedCommand AddCmd = new RoutedCommand();

  public DelegateCmd NewProjCmd { get; private set; } = new();
  public void NewProjCommandExecuted(object? target)
  {
    Projects.Add(new ProjectProxy(new Project("Added proj")));
  }
  public bool NewProjCmdCanExecuted(object? sender)
  {
    return true;
  }


  public DelegateCmd AddCmd { get; private set; } = new();
  private double _num1 =0,_num2,_result=0;
  public double num1 { get { return _num1; } set { if (value == _num1) return; _num1 = value; OnPropertyChanged("num1"); } }
  public double num2 { get { return _num2; } set { if (value == _num2) return; _num2 = value; OnPropertyChanged("num2"); } }
  public double result { get { return _result; } set { if (value == _result) return; _result = value; OnPropertyChanged("result"); } }
  public void AddCommandExecuted(object? target)
  {
    result = num1 + num2;
  }
  public bool AddCommandCanExecuted(object? sender)
  {
    return true;
  }

  public MainWindowViewModel()
  {
    using (var db = App.CreateDbContext())
    {
      if (db.Database.EnsureCreated())
        SeedData.Initialize(db);

      InitCollectionsWithDb(db);
    }

    NewProjCmd.ExecuteHandler = new System.Action<object?>( NewProjCommandExecuted);
    NewProjCmd.CanExecutedHandler = new System.Func<object?, bool>( NewProjCmdCanExecuted);
    AddCmd.CanExecutedHandler = new System.Func<object?, bool>(AddCommandCanExecuted);
    AddCmd.ExecuteHandler = new System.Action<object?>(AddCommandExecuted);
  }



  private async void InitCollectionsWithDb(AppDbContext db)
  {
    db.Database.EnsureCreated();
    var repository = new EfRepository<Project>(db);
    var prjs = await repository.ListAsync(new ProjectsWithItemsSpec());
    //var prjs = await repository.GetBySpecAsync(new ProjectsWithItemsSpec());
    foreach (Project p in prjs)
    {
      ProjectProxy pp = new ProjectProxy(p);
      Projects.Add(pp);
      //TODO: ADD READ TODOITEM FROM DB
    }
  }

   #region changed event
  public event PropertyChangedEventHandler? PropertyChanged;
  public void OnPropertyChanged(string prop)
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
  }
  #endregion
}
