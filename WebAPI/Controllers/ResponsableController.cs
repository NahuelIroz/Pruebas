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
    public class ResponsableController: ControllerBase
    {
        private readonly GestionDeFuentesContext context;


        private readonly ResponsableServicio servicio;

        public ResponsableController(GestionDeFuentesContext contexto)

        {
            context = contexto;
            servicio = new ResponsableServicio(context);
        } 

        [HttpGet("obtenerListadoDeResponsables")]
        public ActionResult<List<ResponsableDTO>> ObtenerListadoDeResponsables()
        {
            try
            {
                List < Responsable> responsables = servicio.ObtenerListadoDeResponsables();

                List < ResponsableDTO> responsablesDTO = new List<ResponsableDTO>();
                if (responsables == null) return responsablesDTO;
                foreach (Responsable responsable in responsables) 
                { 
                    ResponsableDTO responsableDTO = new ResponsableDTO();
                    responsableDTO.id = responsable.id;
                    responsableDTO.nombre = responsable.nombre;
                    responsableDTO.apellido = responsable.apellido;
                    responsableDTO.baja = responsable.baja;
                    responsablesDTO.Add(responsableDTO);
                }
                return responsablesDTO;
                 
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
                 
            }

        }


        [HttpGet("{id:int}")]
        public ActionResult<ResponsableDTO> ObtenerDetalleDeResponsable(int id)
        {
            try
            {
                Responsable responsable = servicio.cargarPorId(id);
                
             
                ResponsableDTO responsableDTO = new ResponsableDTO();
                responsableDTO.id = responsable.id;
                responsableDTO.nombre = responsable.nombre;
                responsableDTO.apellido = responsable.apellido;
                responsableDTO.baja = responsable.baja;
                return responsableDTO;
                 
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest,e.Message);
                 
            }

        }
        [HttpPost]
        public ActionResult<int> DarDeAltaResponsable([FromBody]ResponsableAltaDTO responsableDTO)
        {
            try
            {
                Responsable responsable = new Responsable();
                responsable.nombre = responsableDTO.nombre;
                responsable.apellido = responsableDTO.apellido;
                responsable.FuenteFinanciamiento = new FuenteFinanciamiento();
                responsable.FuenteFinanciamiento = new FuenteFinanciamientoServicio(context).cargarPorId(responsableDTO.fuenteFinanciamientoId);
                int id = servicio.DarDeAltaResponsable(responsable);

                return id;
                 
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
                 
            }

        }


        [HttpPut]
        public ActionResult ModificarResponsable([FromBody] ResponsableModificarDTO responsableDTO)
        {
            try
            {
                Responsable responsable = new Responsable();
                responsable.id = responsableDTO.id;
                responsable.nombre = responsableDTO.nombre;
                responsable.apellido = responsableDTO.apellido; 
                servicio.ModificarResponsable(responsable);

                return Ok();
                 
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
                 
            } 
        }



        [HttpDelete("id:int")]
        public ActionResult DarDeBajaResponsable(int id)
        {
            try
            { 
                servicio.DarDeBajaResponsable(id);

                return Ok(); 
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
                 
            } 
        }
    }
}
