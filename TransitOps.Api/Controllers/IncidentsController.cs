using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransitOps.Api.Data;
using TransitOps.Api.Models;
using TransitOps.Api.Dtos;

namespace TransitOps.Api.Controllers
{
    /// <summary>
    /// API controller responsible for managing transit incident records.
    /// Provides endpoints to create, retrieve, update, and delete incidents.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class IncidentsController : ControllerBase
    {
        private readonly TransitOpsDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="IncidentsController"/> class.
        /// </summary>
        /// <param name="context">Database context for accessing incident data.</param>
        public IncidentsController(TransitOpsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all transit incidents.
        /// </summary>
        /// <returns>A list of incident records.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var incidents = await _context.Incidents
                .Select(i => new IncidentResponseDto
                {
                    Id = i.Id,
                    Title = i.Title,
                    Description = i.Description,
                    Severity = i.Severity,
                    CreatedAt = i.CreatedAt
                })
                .ToListAsync();

            return Ok(incidents);
        }

        /// <summary>
        /// Retrieves a specific incident by its unique identifier.
        /// </summary>
        /// <param name="id">The incident ID.</param>
        /// <returns>The requested incident if found.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var incident = await _context.Incidents.FindAsync(id);
            if (incident == null)
                return NotFound();

            var responseDto = new IncidentResponseDto
            {
                Id = incident.Id,
                Title = incident.Title,
                Description = incident.Description,
                Severity = incident.Severity,
                CreatedAt = incident.CreatedAt
            };

            return Ok(responseDto);
        }

        /// <summary>
        /// Creates a new transit incident.
        /// </summary>
        /// <param name="dto">The incident creation data.</param>
        /// <returns>The newly created incident.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateIncidentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var incident = new Incident
            {
                Title = dto.Title,
                Description = dto.Description,
                Severity = dto.Severity
            };

            _context.Incidents.Add(incident);
            await _context.SaveChangesAsync();

            var responseDto = new IncidentResponseDto
            {
                Id = incident.Id,
                Title = incident.Title,
                Description = incident.Description,
                Severity = incident.Severity,
                CreatedAt = incident.CreatedAt
            };

            return CreatedAtAction(nameof(GetById), new { id = incident.Id }, responseDto);
        }

        /// <summary>
        /// Updates an existing transit incident.
        /// </summary>
        /// <param name="id">The incident ID.</param>
        /// <param name="dto">The updated incident data.</param>
        /// <returns>The updated incident.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateIncidentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var incident = await _context.Incidents.FindAsync(id);
            if (incident == null)
                return NotFound();

            incident.Title = dto.Title;
            incident.Description = dto.Description;
            incident.Severity = dto.Severity;

            await _context.SaveChangesAsync();

            var responseDto = new IncidentResponseDto
            {
                Id = incident.Id,
                Title = incident.Title,
                Description = incident.Description,
                Severity = incident.Severity,
                CreatedAt = incident.CreatedAt
            };

            return Ok(responseDto);
        }

        /// <summary>
        /// Deletes a transit incident.
        /// </summary>
        /// <param name="id">The incident ID.</param>
        /// <returns>No content if deletion is successful.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var incident = await _context.Incidents.FindAsync(id);
            if (incident == null)
                return NotFound();

            _context.Incidents.Remove(incident);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
