using System.ComponentModel.DataAnnotations;
using TransitOps.Api.Models;

namespace TransitOps.Api.Dtos;

/// <summary>
/// Data transfer object used to update an existing transit incident.
/// </summary>
public class UpdateIncidentDto
{
    /// <summary>
    /// Updated title of the incident.
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = "";

    /// <summary>
    /// Updated description detailing the incident.
    /// </summary>
    [Required]
    [MaxLength(500)]
    public string Description { get; set; } = "";

    /// <summary>
    /// Updated severity level of the incident.
    /// </summary>
    [Required]
    public Severity Severity { get; set; } = Severity.Low;
}
