using Microsoft.EntityFrameworkCore;
using MyLondonUnderground.Application.Commands;

namespace MyLondonUnderground.Application.Scaffolding
{
    /// <summary>
    /// This context is only used for MVC scaffolding. 
    /// </summary>
    public class ScaffoldingContext : DbContext
    {
        public ScaffoldingContext()
        {
        }
        public ScaffoldingContext(DbContextOptions<ScaffoldingContext> options) : base(options) 
        {
        }

        public DbSet<AddNewTubeLineCommand> AddNewTubeLineCommand { get; set; }
    }
}
