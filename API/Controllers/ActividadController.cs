using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadesController : ControllerBase
    {
        private readonly Logic _Logic;

        public ActividadesController(Logic Logic)
        {
            _Logic = Logic;
        }

        // Método para insertar una nueva actividad
        [HttpPost]
        public IActionResult PostActividad([FromBody] Actividad actividad)
        {
            if (actividad == null)
            {
                return BadRequest("La actividad no puede ser nula.");
            }

            try
            {
                _Logic.InsertActividad(actividad);
                return CreatedAtAction(nameof(GetActividad), new { idUsuario = actividad.IdUsuario, idJuego = actividad.IdJuego }, actividad);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as required
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        // Método para obtener una actividad por ID de usuario e ID de juego
        [HttpGet("{idUsuario}/{idJuego}")]
        public IActionResult GetActividad(Guid idUsuario, Guid idJuego)
        {
            try
            {
                var actividad = _Logic.GetActividad(idUsuario, idJuego);
                if (actividad == null)
                {
                    return NotFound("Actividad no encontrada.");
                }
                return Ok(actividad);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as required
                return StatusCode(500, "Error interno del servidor.");
            }
        }
        [HttpGet]
        public IActionResult GetAllActividades()
        {
            try
            {
                var actividades = _Logic.GetAllActividades();
                return Ok(actividades);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as required
                return StatusCode(500, "Error interno del servidor.");
            }
        }
    }
}
