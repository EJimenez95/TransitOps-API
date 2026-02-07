using Microsoft.EntityFrameworkCore;
using TransitOps.Api.Models;

namespace TransitOps.Api.Data;

/// <summary>
/// Entity Framework database context for the TransitOps application.
/// Manages access to transit-related data.
/// </summary>
public class TransitOpsDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TransitOpsDbContext"/> class.
    /// </summary>
    /// <param name="options">Database configuration options.</param>
    public TransitOpsDbContext(DbContextOptions<TransitOpsDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Database set representing transit incidents.
    /// </summary>
    public DbSet<Incident> Incidents { get; set; }
}
