using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPharu.Data;
using ApiPharu.Model;
using ApiPharu.Model.Personas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPharu.Controllers
{
     [ApiController]
    [Route("api/Consultarut")]
    public class ConsultaRutController : ControllerBase
    {
         private readonly Payroll _context;

        public ConsultaRutController(Payroll context)  
        {
            _context = context;
        }
          [HttpGet("getconsultarut")]
        public async Task<IActionResult> GetConsultaRut()
        {
            try
            {
                var trabajadores = await _context.Consultaruts.ToListAsync();
                return Ok(trabajadores);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
         [HttpGet("GetConsultaRut/{rut}")]
        public async Task<IActionResult> GetConsultaRut(string rut)
        {
            var trabajadores = await _context.Consultaruts
                                             .Where(t => t.Rut.Equals(rut))
                                             .ToListAsync();

            if (trabajadores == null || !trabajadores.Any())
            {
               var defaultTrabajador = new Consultarut
                {
                    Rut = rut, // Valor fijo para el RUT
                    Estado = "A", // Valor fijo para el Nombre
                    Motivo= "No Encontrado"
                };
                 return NotFound(defaultTrabajador); 
            }

            return  Ok(trabajadores);
        }
        
    }
}