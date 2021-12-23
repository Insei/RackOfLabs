using RackOfLabs.Domain.Base;
using RackOfLabs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
#pragma warning disable CS8618

namespace RackOfLabs.Infrastructure.Persistence.Contexts;

public sealed class DataDbContext : DbContext
{
    //private readonly IAuthenticatedUserService _authenticatedUser;
    
    //public DataDbContext(DbContextOptions<DataDbContext> options, IAuthenticatedUserService authenticatedUser) : base(options)
    public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        // _authenticatedUser = authenticatedUser;
    }
    
    public DbSet<Device> Devices { get; set; }
    public DbSet<DeviceTemplate> DeviceTemplates { get; set; }
    public DbSet<DeviceEthernetPort> DeviceEthernetPorts { get; set; }
    public DbSet<BootStage> BootStages { get; set; }
    public DbSet<BootStageSharedFile> BootStageSharedFiles { get; set; }
    public DbSet<EthernetSwitchTemplate> EthernetSwitchTemplates { get; set; }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created = DateTime.UtcNow;
                    //entry.Entity.CreatedBy = _authenticatedUser.UserId;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModified = DateTime.UtcNow;
                    //entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}