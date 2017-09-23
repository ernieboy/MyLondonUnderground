using Microsoft.EntityFrameworkCore;
using MyLondonUnderground.Domain.Model;

namespace MyLondonUnderground.Infrastructure.EntityFramework
{
    public class LondonUndergroundContext : DbContext
    {
        public LondonUndergroundContext(DbContextOptions<LondonUndergroundContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TubeLineToTubeLineStationMap>()
            .HasKey(tltls => new { tltls.TubeLineId, tltls.TubeLineStationId });

            modelBuilder.Entity<TubeLineToTubeLineStationMap>()
                .HasOne(tltls => tltls.TubeLine)
                .WithMany(m => m.TubeLineToTubeLineStationMaps)
                .HasForeignKey(tltls => tltls.TubeLineId);

            modelBuilder.Entity<TubeLineToTubeLineStationMap>()
                .HasOne(tltls => tltls.TubeLineStation)
                .WithMany(m => m.TubeLineToTubeLineStationMaps)
                .HasForeignKey(tltls => tltls.TubeLineStationId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TubeLine> TubeLines
        {
            get;
            set;
        }

        public DbSet<TubeLineStation> TubeLineStations
        {
            get;
            set;
        }
    }
}
