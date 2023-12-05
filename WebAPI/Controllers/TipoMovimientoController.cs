using GestionDeFuentes.Context;
using GestionDeFuentes.Modelo;
using GestionDeFuentes.Servicios;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoMovimientoController : ControllerBase
    {
        private  readonly GestionDeFuentesContext context;


        private readonly TipoMovimientoServicio servicio; 

        public TipoMovimientoController(GestionDeFuentesContext contexto)

        {
            context = contexto;
            servicio=new TipoMovimientoServicio(context);
        }

        [HttpGet("obtenerListadoDeTiposMovimiento/{id:int}")]
        public ActionResult<List<TipoMovimientoDTO>> ObtenerListadoDeTipoMovimiento()
        {
            try
            {
                List<TipoMovimiento> tiposMovimiento = servicio.ObtenerListadoDeTiposMovimiento();
                List<TipoMovimientoDTO> tiposMovimientoDTO = new List<TipoMovimientoDTO>();

                if (tiposMovimiento == null) return tiposMovimientoDTO;
                foreach (TipoMovimiento tipoMovimiento in tiposMovimiento)
                {
                    TipoMovimientoDTO tipoMovimientoDTO = new TipoMovimientoDTO();
                    tipoMovimientoDTO.id = tipoMovimiento.id;
                    tipoMovimientoDTO.codigo = tipoMovimiento.codigo;
                    tipoMovimientoDTO.descripcion = tipoMovimiento.descripcion;
                    tipoMovimientoDTO.baja = tipoMovimiento.baja;
                    tiposMovimientoDTO.Add(tipoMovimientoDTO);
                }

                return tiposMovimientoDTO;


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);


            }

        }

        [HttpGet("{id:int}")]
        public ActionResult<TipoMovimientoDTO> ObtenerDetalleDeTipoMovimiento(int id)
        {
            try
            {
                TipoMovimiento tipoMovimiento = servicio.cargarPorId(id);

                TipoMovimientoDTO tipoMovimientoDTO = new TipoMovimientoDTO();
                tipoMovimientoDTO.id = tipoMovimiento.id;
                tipoMovimientoDTO.codigo = tipoMovimiento.codigo;
                tipoMovimientoDTO.descripcion = tipoMovimiento.descripcion;
                tipoMovimientoDTO.baja = tipoMovimiento.baja;
                return tipoMovimientoDTO;


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);


            }

        }

        [HttpPost]
        public ActionResult<int> RegistrarTipoMovimiento([FromBody] TipoMovimientoAltaDTO tipoMovimientoDTO)
        {
            try
            {
                TipoMovimiento tipoMovimiento = new TipoMovimiento(); 
                tipoMovimiento.codigo = tipoMovimientoDTO.codigo;
                tipoMovimiento.descripcion = tipoMovimientoDTO.descripcion;
                int id = servicio.DarDeAltaTipoMovimiento(tipoMovimiento);

                return id;


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);


            }

        }
        [HttpPut]
        public ActionResult ModificarTipoMovimiento([FromBody] TipoMovimientoModificarDTO tipoMovimientoDTO)
        {
            try
            {
                TipoMovimiento tipoMovimiento = new TipoMovimiento();
                tipoMovimiento.id = tipoMovimientoDTO.id;
                tipoMovimiento.codigo = tipoMovimientoDTO.codigo;
                tipoMovimiento.descripcion = tipoMovimientoDTO.descripcion;
                servicio.ModificarTipoMovimiento(tipoMovimiento);

                return Ok();


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);


            }

        }



        [HttpDelete("id:int")]
        public ActionResult DarDeBajaTipoMovimiento(int id)
        {
            try
            {

                servicio.DarDeBajaTipoMovimiento(id);

                return Ok();


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);


            }

        }

    }
}