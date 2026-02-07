using TransitOps.Api.Models;

namespace TransitOps.Api.Dtos;

/// <summary>
/// Data transfer object returned to clients when retrieving incident data.
/// </summary>
public class IncidentResponseDto
{
    /// <summary>
    /// Unique identifier of the incident.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Title describing the incident.
    /// </summary>
    public string Title { get; set; } = "";

    /// <summary>
    /// Detailed description of the incident.
    /// </summary>
    public string Description { get; set; } = "";

    /// <summary>
    /// Severity level of the incident.
    /// </summary>
    public Severity Severity { get; set; } = Severity.Low;

    /// <summary>
    /// Date and time when the incident was created (UTC).
    /// </summary>
    public DateTime CreatedAt { get; set; }
}
