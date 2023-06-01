using McLaren.Models;
using Microsoft.EntityFrameworkCore;

namespace McLaren.MyDataContext;

public class MyDbContext : DbContext
{
    public MyDbContext()
    { }

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<FileModel> Files { get; set; }
    
}