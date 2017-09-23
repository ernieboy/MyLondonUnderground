using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyLondonUnderground.Infrastructure.EntityFramework
{
    public class LondonUndergroundContextFactory : IDesignTimeDbContextFactory<LondonUndergroundContext>
    {
        public LondonUndergroundContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LondonUndergroundContext>();
            optionsBuilder.UseSqlite("Data Source=app.db");

            return new LondonUndergroundContext(optionsBuilder.Options);
        }
    }
}
