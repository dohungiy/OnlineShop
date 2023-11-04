using Microsoft.EntityFrameworkCore;
using SharedKernel.Core;
using SharedKernel.Persistence;

namespace SharedKernel.Domain.DomainEvents;

public class EventDbContext : AppDbContext
{
    private readonly string _dbConfig;

    public EventDbContext(string dbConfig = "MasterDb") : base(default)
    {
        _dbConfig = dbConfig;
    }
    public DbSet<Event> Events { get; set; }
    public DbSet<AuditEntity> AuditEntities { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(CoreSettings.ConnectionStrings[_dbConfig]);
    }

    public override async Task CommitAsync(bool dispatchEvent = true, CancellationToken cancellationToken = default)
    {
        await this.SaveChangesAsync(cancellationToken);
    }

    protected override void ProcessDomainEvents()
    {
        
    }
}

