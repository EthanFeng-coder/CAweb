
using CA.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CA.Db;

public class AppDbContext : DbContext
{


    public DbSet<User> Users { get; set; }
    public DbSet<Text> Texts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    { 
        // connect to mysql with connection string from app settings
        options.UseMySQL("server = localhost;database = AuthenticationApi;uid = root ; pwd = 123456");
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

}