using System.ComponentModel.DataAnnotations;
using TransitOps.Api.Models;

namespace TransitOps.Api.Dtos;

/// <summary>
/// Data transfer object used to create a new transit incident.
/// </summary>
public class CreateIncidentDto
{
    /// <summary>
    /// Title describing the incident.
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = "";

    /// <summary>
    /// Detailed description of the incident.
    /// </summary>
    [Required]
    [MaxLength(500)]
    public string Description { get; set; } = "";

    /// <summary>
    /// Severity level of the incident.
    /// </summary>
    [Required]
    public Severity Severity { get; set; } = Severity.Low;
}
