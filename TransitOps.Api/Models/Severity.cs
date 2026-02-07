namespace TransitOps.Api.Models;

/// <summary>
/// Represents the severity level of a transit incident.
/// Used to help prioritize response and resolution.
/// </summary>
public enum Severity
{
    /// <summary>
    /// Minor issue with little to no service impact.
    /// </summary>
    Low,

    /// <summary>
    /// Moderate issue that may cause delays or limited disruption.
    /// </summary>
    Medium,

    /// <summary>
    /// Major issue causing significant service disruption.
    /// </summary>
    High,

    /// <summary>
    /// Critical issue requiring immediate attention and response.
    /// </summary>
    Critical
}
