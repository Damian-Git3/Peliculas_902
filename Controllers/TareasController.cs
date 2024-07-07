using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareasAPI_902.Models;

namespace TareasAPI_902.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        /* VARIABLE DE CONTEXTO */
        private readonly BdTareas902Context _bdTareas;

        /* 
            --CONSTUCTOR DEL CONTROLADOR--
            Creamos una instancia de la clase de Contexto de la base de datos
            La asignamos a la variable de contexto para todas las operaciones de base de datos
         */
        public TareasController(BdTareas902Context bdTareas)
        {
            _bdTareas = bdTareas;
        }


        /* METODO API QUE OBTIENE TODAS LAS TAREAS DE BD */
        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> Lista()
        {
            var listaTareas = await _bdTareas.Tareas.ToListAsync();

            return Ok(listaTareas);
        }

        /* METODO API PARA AGREGAR UNA NUEVA TAREA*/
        [HttpPost]
        [Route("agregar")]
        public async Task<IActionResult> Agregar([FromBody] Tarea request)

        {
            await _bdTareas.Tareas.AddAsync(request);
            await _bdTareas.SaveChangesAsync();
            return Ok(request);
        }

        /* METODO API PARA MODIFICAR UNA TAREA*/
        [HttpPut]
        [Route("modificar")]
        public async Task<IActionResult> Modificar(int id, [FromBody] Tarea request)

        {
            /* Buscamos la tarea para verificar si existe por medio de su id */
            var tareaModificar = await _bdTareas.Tareas.FindAsync(id);

            if (tareaModificar == null)
            {
                return BadRequest("Metodo No Encontrado");
            }

            /* ASIGNAMOS LOS NUEVOS VALORES */
            tareaModificar.Nombre = request.Nombre;

            try
            {
                /* GUARDAMOS LOS CAMBIOS */
                await _bdTareas.SaveChangesAsync();
            }
            catch
            {
                return NotFound();
            }

            return Ok(request);
        }

        /* METODO PARA ELIMINAR UNA TAREA */
        [HttpDelete]
        [Route("eliminar")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var tareaEliminar = await _bdTareas.Tareas.FindAsync(id);
            if (tareaEliminar == null)
            {
                return BadRequest("Metodo No Encontrado");
            }

            _bdTareas.Tareas.Remove(tareaEliminar);
            await _bdTareas.SaveChangesAsync();

            return Ok();
        }

    }
}
