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
    public class TipoFondoController : ControllerBase
    {
        private readonly GestionDeFuentesContext context;


        private readonly TipoFondoServicio servicio;

        public TipoFondoController(GestionDeFuentesContext contexto)

        {
            context = contexto;
            servicio = new TipoFondoServicio(context);
        } 
        [HttpGet("obtenerListadoDeTipoFondo/{id:int}")]
        public ActionResult<List<TipoFondoDTO>> ObtenerListadoDeTipoFondo( )
        {
            try
            {
                List < TipoFondo> tiposFondo = servicio.ObtenerListadoDeTipoFondo();
                List<TipoFondoDTO> tiposFondoDTO = new List<TipoFondoDTO>();

                if (tiposFondo == null) return tiposFondoDTO;
                foreach (TipoFondo tipoFondo in tiposFondo)
                {
                    TipoFondoDTO tipoFondoDTO = new TipoFondoDTO();
                    tipoFondoDTO.id = tipoFondo.id;
                    tipoFondoDTO.codigo = tipoFondo.codigo;
                    tipoFondoDTO.descripcion = tipoFondo.descripcion;
                    tipoFondoDTO.baja = tipoFondo.baja;
                    tiposFondoDTO.Add(tipoFondoDTO);    
                }
               
                return tiposFondoDTO;


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);


            }

        }

        [HttpGet("{id:int}")]
        public ActionResult<TipoFondoDTO> ObtenerDetalleDeTipoFondo(int id)
        {
            try
            {
                TipoFondo tipoFondo = servicio.cargarPorId(id);

                TipoFondoDTO tipoFondoDTO = new TipoFondoDTO();
                tipoFondoDTO.id = tipoFondo.id;
                tipoFondoDTO.codigo = tipoFondo.codigo;
                tipoFondoDTO.descripcion = tipoFondo.descripcion;
                tipoFondoDTO.baja = tipoFondo.baja; 
                return tipoFondoDTO;


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);


            }

        }

        [HttpPost]
        public ActionResult<int> RegistrarTipoFondo([FromBody] TipoFondoAltaDTO tipoFondoDTO)
        {
            try
            {
                TipoFondo tipoFondo = new TipoFondo(); 
                tipoFondo.codigo = tipoFondoDTO.codigo;
                tipoFondo.descripcion = tipoFondoDTO.descripcion; 
                int id = servicio.DarDeAltaTipoFondo(tipoFondo);

                return id;


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);


            }

        }
        [HttpPut]
        public ActionResult ModificarTipoFondo([FromBody] TipoFondoModificarDTO tipoFondoDTO)
        {
            try
            {
                TipoFondo TipoFondo = new TipoFondo();
                TipoFondo.id = tipoFondoDTO.id;
                TipoFondo.codigo = tipoFondoDTO.codigo;
                TipoFondo.descripcion = tipoFondoDTO.descripcion;
                servicio.ModificarTipoFondo(TipoFondo);

                return Ok();


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);


            }

        }



        [HttpDelete("id:int")]
        public ActionResult DarDeBajaTipoFondo(int id)
        {
            try
            {

                servicio.DarDeBajaTipoFondo(id);

                return Ok();


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);


            }

        }
    }
}
