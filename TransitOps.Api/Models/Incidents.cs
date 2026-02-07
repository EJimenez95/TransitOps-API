using System.ComponentModel.DataAnnotations;

namespace TransitOps.Api.Models;

/// <summary>
/// Represents a transit service incident recorded by the system.
/// </summary>
public class Incident
{
    /// <summary>
    /// Unique identifier for the incident.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Short title describing the incident.
    /// </summary>
    [Required, MaxLength(100)]
    public string Title { get; set; } = "";

    /// <summary>
    /// Detailed description of the incident and its impact.
    /// </summary>
    [Required, MaxLength(500)]
    public string Description { get; set; } = "";

    /// <summary>
    /// Severity level of the incident used for prioritization.
    /// </summary>
    [Required]
    public Severity Severity { get; set; } = Severity.Low;

    /// <summary>
    /// Timestamp indicating when the incident was created (UTC).
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
