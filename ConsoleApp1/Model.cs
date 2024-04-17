using Microsoft.EntityFrameworkCore;

public class CalcDbContext : DbContext
{
    public DbSet<Calculus> Calculus { get; set; }

    public string DbPath { get; }

    public CalcDbContext()
    {
        var folder = Environment.SpecialFolder.CommonDocuments;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "calc.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

