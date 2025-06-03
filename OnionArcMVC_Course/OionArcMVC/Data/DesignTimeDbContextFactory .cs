using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using RepositryLayer;

namespace OionArcMVC.Data
{
    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    //{
    //    public ApplicationContext CreateDbContext(string[] args)
    //    {
    //        IConfigurationRoot configuration = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json")
    //            .Build();
    //        var builder = new DbContextOptionsBuilder<ApplicationContext>();
    //        var connectionString = configuration.GetConnectionString("DefaultConnection");
    //        builder.UseSqlServer(connectionString);
    //        return new ApplicationContext(builder.Options);
    //    }
    //}
}
