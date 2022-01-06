using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Clean.Architecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Wpf
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {

    protected override void OnStartup(StartupEventArgs e)
    {
    }

    public static AppDbContext CreateDbContext()
    {
      string conn = ConfigurationManager
                      .ConnectionStrings["sqliteConnection"]
                      .ConnectionString;
      var ob = new DbContextOptionsBuilder<AppDbContext>();
      ob.UseSqlite(conn);
      return new AppDbContext(ob.Options, null);
    }
  }

}
