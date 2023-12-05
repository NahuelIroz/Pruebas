using GestionDeFuentes.Context;
using GestionDeFuentes.Modelo;
using GestionDeFuentes.Servicios;
using Microsoft.AspNetCore.Mvc; 
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimientoController : ControllerBase
    {
        private  readonly GestionDeFuentesContext context;


        private readonly MovimientoServicio servicio; 

        public MovimientoController(GestionDeFuentesContext contexto) //este metodo es un consructor, lo de adentro instacia el contecto y el servicio

        {
            context = contexto;
            servicio=new MovimientoServicio(context);
        }


         

        [HttpGet("obtenerListadoDeMovimientosDeFuenteDeFinanciamiento/{id:int}")]
        public ActionResult<List<MovimientoDTO>> ObtenerListadoDeMovimientosDeFuenteDeFinanciamiento(int id)
        {
            try
            {
                List<Movimiento> movimientos = servicio.ObtenerListadoDeMovimientosDeFuenteDeFinanciamiento(id);

                List < MovimientoDTO> movimientosDTO=new List<MovimientoDTO>();
                if (movimientos == null) return movimientosDTO;
                foreach (Movimiento movimiento in movimientos) 
                {
                    MovimientoDTO movimientoDTO = new MovimientoDTO();
                    movimientoDTO.id = movimiento.id;
                    movimientoDTO.saldo = movimiento.saldo;
                    movimientoDTO.baja = movimiento.baja;
                    movimientoDTO.tipoMovimiento = new TipoMovimientoDTO();
                    movimientoDTO.tipoMovimiento.id = movimiento.tipoMovimiento.id;
                    movimientoDTO.tipoMovimiento.codigo = movimiento.tipoMovimiento.codigo;
                    movimientoDTO.tipoMovimiento.descripcion = movimiento.tipoMovimiento.descripcion;
                    movimientoDTO.tipoMovimiento.baja = movimiento.tipoMovimiento.baja;

                    movimientoDTO.fuenteFinanciamiento = new FuenteFinanciamientoDTO();
                    movimientoDTO.fuenteFinanciamiento.id = movimiento.fuenteFinanciamiento.id;
                    movimientoDTO.fuenteFinanciamiento.motivo = movimiento.fuenteFinanciamiento.motivo;
                    movimientoDTO.fuenteFinanciamiento.fecha_acreditacion = movimiento.fuenteFinanciamiento.fecha_acreditacion;
                    movimientoDTO.fuenteFinanciamiento.saldo = movimiento.fuenteFinanciamiento.saldo;
                    movimientoDTO.fuenteFinanciamiento.observaciones = movimiento.fuenteFinanciamiento.observaciones;
                    movimientoDTO.fuenteFinanciamiento.tipoFondo = new TipoFondoDTO();
                    movimientoDTO.fuenteFinanciamiento.tipoFondo.id = movimiento.fuenteFinanciamiento.tipoFondo.id;
                    movimientoDTO.fuenteFinanciamiento.tipoFondo.codigo = movimiento.fuenteFinanciamiento.tipoFondo.codigo;
                    movimientoDTO.fuenteFinanciamiento.tipoFondo.baja = movimiento.fuenteFinanciamiento.tipoFondo.baja;
                    movimientoDTO.fuenteFinanciamiento.tipoFondo.descripcion = movimiento.fuenteFinanciamiento.tipoFondo.descripcion;
                    movimientoDTO.fuenteFinanciamiento.movimientos = new List<MovimientoDTO>();

                    movimientoDTO.fuenteFinanciamiento.proyecto = new ProyectoDTO();
                    movimientoDTO.fuenteFinanciamiento.proyecto.id = movimiento.fuenteFinanciamiento.proyecto.id;
                    movimientoDTO.fuenteFinanciamiento.proyecto.nombre = movimiento.fuenteFinanciamiento.proyecto.nombre;
                    movimientoDTO.fuenteFinanciamiento.responsables = new List<ResponsableDTO>(); 
                    movimientoDTO.fuenteFinanciamiento.baja = movimiento.fuenteFinanciamiento.baja; 
                    movimientosDTO.Add( movimientoDTO );
                }
              
                return movimientosDTO;


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);

            }

        }
        [HttpGet("{id:int}")]
        public ActionResult<MovimientoDTO> ObtenerDetalleDeMovimiento(int id)
        {
            try
            {
                Movimiento movimiento = servicio.cargarPorId(id);
             
                MovimientoDTO movimientoDTO = new MovimientoDTO();
                movimientoDTO.id = movimiento.id;
                movimientoDTO.saldo = movimiento.saldo;
                movimientoDTO.baja=movimiento.baja;
                movimientoDTO.tipoMovimiento = new TipoMovimientoDTO();  
                movimientoDTO.tipoMovimiento.id = movimiento.tipoMovimiento.id;
                movimientoDTO.tipoMovimiento.codigo = movimiento.tipoMovimiento.codigo;
                movimientoDTO.tipoMovimiento.descripcion = movimiento.tipoMovimiento.descripcion;
                movimientoDTO.tipoMovimiento.baja = movimiento.tipoMovimiento.baja;
                 
                movimientoDTO.fuenteFinanciamiento = new FuenteFinanciamientoDTO();
                movimientoDTO.fuenteFinanciamiento.id = movimiento.fuenteFinanciamiento.id;
                movimientoDTO.fuenteFinanciamiento.motivo = movimiento.fuenteFinanciamiento.motivo;
                movimientoDTO.fuenteFinanciamiento.fecha_acreditacion = movimiento.fuenteFinanciamiento.fecha_acreditacion;
                movimientoDTO.fuenteFinanciamiento.saldo = movimiento.fuenteFinanciamiento.saldo;
                movimientoDTO.fuenteFinanciamiento.observaciones = movimiento.fuenteFinanciamiento.observaciones;
                movimientoDTO.fuenteFinanciamiento.tipoFondo = new TipoFondoDTO();
                movimientoDTO.fuenteFinanciamiento.tipoFondo.id = movimiento.fuenteFinanciamiento.tipoFondo.id;
                movimientoDTO.fuenteFinanciamiento.tipoFondo.codigo = movimiento.fuenteFinanciamiento.tipoFondo.codigo;
                movimientoDTO.fuenteFinanciamiento.tipoFondo.baja = movimiento.fuenteFinanciamiento.tipoFondo.baja;
                movimientoDTO.fuenteFinanciamiento.tipoFondo.descripcion = movimiento.fuenteFinanciamiento.tipoFondo.descripcion;
                movimientoDTO.fuenteFinanciamiento.movimientos = new List<MovimientoDTO>();

                movimientoDTO.fuenteFinanciamiento.proyecto = new ProyectoDTO();
                movimientoDTO.fuenteFinanciamiento.proyecto.id = movimiento.fuenteFinanciamiento.proyecto.id;
                movimientoDTO.fuenteFinanciamiento.proyecto.nombre = movimiento.fuenteFinanciamiento.proyecto.nombre;
                movimientoDTO.fuenteFinanciamiento.responsables = new List<ResponsableDTO>(); 
                movimientoDTO.fuenteFinanciamiento.baja = movimiento.fuenteFinanciamiento.baja;

                return movimientoDTO;
                 
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest,e.Message); 
        
            } 
        }

        [HttpPost]
        public ActionResult<int> DarDeAltaMovimiento ([FromBody] MovimientoAltaDTO movimientoDTO)
        {
            try
            {
                Movimiento movimiento = new Movimiento();
                movimiento.saldo = movimientoDTO.saldo; 
                movimiento.descripcion = movimientoDTO.descripcion;
                movimiento.fecha = movimientoDTO.fecha;
                movimiento.tipoMovimiento = new TipoMovimiento();
                movimiento.tipoMovimiento= new TipoMovimientoServicio(context).cargarPorId(movimientoDTO.tipoMovimientoId);
                movimiento.fuenteFinanciamiento = new FuenteFinanciamiento();
                movimiento.fuenteFinanciamiento = new FuenteFinanciamientoServicio(context).cargarPorId(movimientoDTO.fuenteFinanciamientoId);
                int id = servicio.DarDeAltaMovimiento(movimiento);

                return id;
 
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
                 
            } 
        }


        [HttpPut]
        public ActionResult ModificarMovimiento([FromBody] MovimientoModificarDTO movimientoDTO)
        {
            try
            {
                Movimiento movimiento = new Movimiento();
                movimiento.id = movimientoDTO.id;
                movimiento.saldo = movimientoDTO.saldo;
                movimiento.descripcion = movimientoDTO.descripcion; 
                movimiento.tipoMovimiento = new TipoMovimiento();
                movimiento.tipoMovimiento= new TipoMovimientoServicio(context).cargarPorId(movimientoDTO.tipoMovimientoId);

                servicio.ModificarMovimiento(movimiento);

                return Ok();
                 
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
                 
            } 
        }



        [HttpDelete("id:int")]
        public ActionResult DarDeBajaMovimiento(int id)
        {
            try
            { 
                servicio.DarDeBajaMovimiento(id);

                return Ok();
 
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
                 
            }

        }
    }
}