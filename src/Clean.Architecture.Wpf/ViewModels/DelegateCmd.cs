using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Clean.Architecture.Wpf.ViewModels;

internal class DelegateCmd : ICommand
{
#pragma warning disable CS0067
  public event EventHandler? CanExecuteChanged;
#pragma warning restore CS0067
  public bool CanExecute(object? parameter)
  {
    if(CanExecutedHandler != null)
      return CanExecutedHandler.Invoke(parameter);
    else return true;
  }

  public void Execute(object? parameter)
  {
    ExecuteHandler?.Invoke(parameter);
  }

  public Action<object?>? ExecuteHandler { get; set; }
  public Func<object?, bool>? CanExecutedHandler { get; set; }
}
