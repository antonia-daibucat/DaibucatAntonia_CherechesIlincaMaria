namespace DaibucatAntonia_CherechesIlincaMaria.Controllers;
using DaibucatAntonia_CherechesIlincaMaria.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;



[Route("api/[controller]")]
[ApiController]
public class ClientApiController : ControllerBase
{
    private readonly DaibucatAntonia_CherechesIlincaMariaContext _context;

    public ClientApiController(DaibucatAntonia_CherechesIlincaMariaContext context)
    {
        _context = context;
    }

  
    [HttpGet("GroupClasses")]
    [AllowAnonymous]
    public async Task<IActionResult> GetGroupClasses()
    {
        try
        {

            var clase = await _context.ClasaFitness
                 .Select(c => new
                 {
                     c.Id,
                     c.NumeClasa,
                     c.Descriere,
                     c.Antrenor,
                     c.Zi,
                     OraInceput = c.Ora, 
                 })
                
                 .OrderBy(c => c.Zi)
                 .ToListAsync();

            return Ok(clase);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Eroare: {ex.Message}");
        }
    }
}