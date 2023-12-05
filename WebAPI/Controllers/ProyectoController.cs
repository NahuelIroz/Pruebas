using GestionDeFuentes.Context;
using GestionDeFuentes.Modelo;
using GestionDeFuentes.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProyectoController : ControllerBase
    {
        private readonly GestionDeFuentesContext context;


        private readonly ProyectoServicio servicio;

        public ProyectoController(GestionDeFuentesContext contexto)

        {
            context = contexto;
            servicio = new ProyectoServicio(context);
        }
        [HttpGet("obtenerListadoDeProyectos")]
        public ActionResult<List<ProyectoDTO>> ObtenerListadoDeProyectos()
        {
            try
            {
                List<Proyecto> proyectos = servicio.ObtenerListadoDeProyectos();

                List<ProyectoDTO> proyectosDTO = new List<ProyectoDTO>();
                if (proyectos == null) { return proyectosDTO; }
                foreach (Proyecto proyecto in proyectos)
                {
                    ProyectoDTO proyectoDTO = new ProyectoDTO();
                    proyectoDTO.id = proyecto.id;
                    proyectoDTO.nombre = proyecto.nombre;
                    proyectoDTO.baja = proyecto.baja;
                    proyectoDTO.fuentesFinanciamiento = new List<FuenteFinanciamientoDTO>(); 
                    proyectosDTO.Add(proyectoDTO);
                }


                return proyectosDTO;


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);


            }

        }
        [HttpGet("{id:int}")]
        public ActionResult<ProyectoDTO> ObtenerDetalleDeProyecto(int id)
        {
            try
            {
                Proyecto proyecto = servicio.cargarPorId(id);
                
                ProyectoDTO proyectoDTO = new ProyectoDTO();
                proyectoDTO.id = proyecto.id;
                proyectoDTO.nombre = proyecto.nombre;
                proyectoDTO.baja = proyecto.baja;
                proyectoDTO.fuentesFinanciamiento = new List<FuenteFinanciamientoDTO>(); 
                
                return proyectoDTO;


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);


            }

        }

        [HttpPost]
        public ActionResult<int> DarDeAltaProyecto([FromBody] ProyectoAltaDTO proyectoDTO)
        {
            try
            {
                Proyecto proyecto = new Proyecto();
                proyecto.nombre = proyectoDTO.nombre; 
                proyecto.fuentesFinanciamiento = new List<FuenteFinanciamiento>();
                int id = servicio.DarDeAltaProyecto(proyecto);

                return id;


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);


            }

        }


        [HttpPut]
        public ActionResult ModificarProyecto([FromBody] ProyectoModificarDTO proyectoDTO)
        {
            try
            {
               Proyecto proyecto = new Proyecto();
                proyecto.id = proyectoDTO.id;
                proyecto.nombre = proyectoDTO.nombre; 
                servicio.ModificarProyecto(proyecto);

                return Ok();


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);


            }

        }



        [HttpDelete("id:int")]
        public ActionResult DarDeBajaProyecto(int id)
        {
            try
            {

                servicio.DarDeBajaProyecto(id);

                return Ok();


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);


            }

        }
    }
}
