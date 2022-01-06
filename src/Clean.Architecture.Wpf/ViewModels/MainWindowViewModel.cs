using Clean.Architecture.Core.ProjectAggregate;
using Clean.Architecture.Infrastructure.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace Clean.Architecture.Wpf.ViewModels;

internal class MainWindowViewModel : INotifyPropertyChanged
{
  protected ObservableCollection<ProjectProxy> _projects = new();
  public ObservableCollection<ProjectProxy> Projects { get => _projects; }

  public MainWindowViewModel()
  {
    using (var db = App.CreateDbContext())
    {
      if (db.Database.EnsureCreated())
        SeedData.Initialize(db);

      InitCollectionsWithDb(db);
    }
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
