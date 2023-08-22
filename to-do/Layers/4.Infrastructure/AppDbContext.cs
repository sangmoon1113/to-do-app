using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace to_do.Layers._4.Infrastructure;
public class AppDbContext : DbContext
{
    public DbSet<ScheduleEntity> Schedules
    {
        get; set; 
    }

    public string DbFile
    {
        get;
    }

    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbFile = System.IO.Path.Join(path, "todo.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbFile}");
}
