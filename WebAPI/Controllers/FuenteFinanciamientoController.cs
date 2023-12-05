
using GestionDeFuentes.Context;
using GestionDeFuentes.Modelo;
using GestionDeFuentes.Servicios;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuenteFinanciamientoController : ControllerBase
    {
        private readonly GestionDeFuentesContext context;


        private readonly FuenteFinanciamientoServicio servicio;

        public FuenteFinanciamientoController(GestionDeFuentesContext contexto) //este metodo es un consructor, lo de adentro instacia el contecto y el servicio

        {
            context = contexto;
            servicio = new FuenteFinanciamientoServicio(context);
        }

        [HttpGet("{id:int}")]
        public ActionResult<FuenteFinanciamientoDTO> ObtenerDetalleDeFuenteFinanciamiento(int id)
        {
            try
            {
                FuenteFinanciamiento fuente = servicio.cargarPorId(id);
                
                FuenteFinanciamientoDTO fuenteDTO = new FuenteFinanciamientoDTO();
                fuenteDTO.id = fuente.id;
                fuenteDTO.motivo = fuente.motivo;
                fuenteDTO.fecha_acreditacion = fuente.fecha_acreditacion;
                fuenteDTO.saldo=fuente.saldo; 
                fuenteDTO.observaciones=fuente.observaciones;
                fuenteDTO.tipoFondo= new TipoFondoDTO(); 
                fuenteDTO.tipoFondo.id = fuente.tipoFondo.id;
                fuenteDTO.tipoFondo.codigo = fuente.tipoFondo.codigo;
                fuenteDTO.tipoFondo.baja = fuente.tipoFondo.baja;
                fuenteDTO.tipoFondo.descripcion = fuente.tipoFondo.descripcion;
                fuenteDTO.movimientos = new List<MovimientoDTO>();
                fuente.movimientos = new List<Movimiento>();
                fuente.movimientos = new MovimientoServicio(context).ObtenerListadoDeMovimientosDeFuenteDeFinanciamiento(fuente.id);
                if (fuente.movimientos !=null && fuente.movimientos.Count > 0) 
                {
                        foreach (Movimiento m in fuente.movimientos) 
                        {
                            MovimientoDTO movimientoDTO = new MovimientoDTO();
                            movimientoDTO.id = m.id;
                            movimientoDTO.saldo = m.saldo;
                            movimientoDTO.baja = m.baja;
                            movimientoDTO.descripcion = m.descripcion;
                            movimientoDTO.fecha = m.fecha;
                            movimientoDTO.tipoMovimiento = new TipoMovimientoDTO();
                            movimientoDTO.tipoMovimiento.id = m.tipoMovimiento.id;
                            movimientoDTO.tipoMovimiento.codigo = m.tipoMovimiento.codigo;
                            movimientoDTO.tipoMovimiento.baja = m.tipoMovimiento.baja;
                            movimientoDTO.tipoMovimiento.descripcion = m.tipoMovimiento.descripcion;
                            fuenteDTO.movimientos.Add( movimientoDTO );
                        }
                }
               
                fuenteDTO.proyecto = new ProyectoDTO();
                fuenteDTO.proyecto.id = fuente.proyecto.id;
                fuenteDTO.proyecto.nombre = fuente.proyecto.nombre;
                fuenteDTO.responsables = new List<ResponsableDTO>();
                if (fuente.responsables != null && fuente.responsables.Count > 0)
                {
                    foreach (Responsable responable in fuente.responsables)
                    {
                        ResponsableDTO rDTO = new ResponsableDTO();

                        rDTO.id = responable.id;
                        rDTO.nombre = responable.nombre;
                        rDTO.apellido = responable.apellido;
                        rDTO.baja = responable.baja;
                        fuenteDTO.responsables.Add(rDTO);
                    }
                }
                fuenteDTO.baja = fuente.baja;
                return fuenteDTO;


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
                 
            }

        }

        [HttpGet("obtenerListadoDeFuentesDeFinanciamientoPorProyecto/{id:int}")]
        public ActionResult<List<FuenteFinanciamientoDTO>> ObtenerListadoDeFuentesDeFinanciamientoPorProyecto(int id)
        {
            try
            {
                List<FuenteFinanciamiento> fuentes = servicio.ObtenerListadoDeFuentesFinanciamientoDeProyecto(id);
                List<FuenteFinanciamientoDTO> fuentesDTO = new List<FuenteFinanciamientoDTO>();
                if (fuentes == null) return fuentesDTO;
                foreach (FuenteFinanciamiento fuente in fuentes)
                {
                     FuenteFinanciamientoDTO fuenteDTO = new FuenteFinanciamientoDTO();
                    fuenteDTO.id = fuente.id;
                    fuenteDTO.saldo = fuente.saldo;
                    fuenteDTO.fecha_acreditacion = fuente.fecha_acreditacion;
                    fuenteDTO.motivo = fuente.motivo; 
                    fuenteDTO.observaciones = fuente.observaciones; 
                    fuenteDTO.tipoFondo = new TipoFondoDTO();
                    fuenteDTO.tipoFondo.id = fuente.tipoFondo.id;
                    fuenteDTO.tipoFondo.codigo = fuente.tipoFondo.codigo;
                    fuenteDTO.tipoFondo.descripcion = fuente.tipoFondo.descripcion;
                    fuenteDTO.tipoFondo.baja = fuente.tipoFondo.baja;
                    fuenteDTO.movimientos = new List<MovimientoDTO>();
                    foreach (Movimiento m in fuente.movimientos)
                    {
                        MovimientoDTO movimientoDTO = new MovimientoDTO();
                        movimientoDTO.id = m.id;
                        movimientoDTO.saldo = m.saldo;
                        movimientoDTO.baja = m.baja;
                        movimientoDTO.descripcion = m.descripcion;
                        movimientoDTO.fecha = m.fecha;
                        movimientoDTO.tipoMovimiento = new TipoMovimientoDTO();
                        movimientoDTO.tipoMovimiento.id = m.tipoMovimiento.id;
                        movimientoDTO.tipoMovimiento.codigo = m.tipoMovimiento.codigo;
                        movimientoDTO.tipoMovimiento.baja = m.tipoMovimiento.baja;
                        movimientoDTO.tipoMovimiento.descripcion = m.tipoMovimiento.descripcion;
                        fuenteDTO.movimientos.Add(movimientoDTO);
                    }
                    fuenteDTO.proyecto = new ProyectoDTO();
                    fuenteDTO.proyecto.id = fuente.proyecto.id;
                    fuenteDTO.proyecto.nombre = fuente.proyecto.nombre;
                    fuenteDTO.responsables = new List<ResponsableDTO>();
                    foreach (Responsable responable in fuente.responsables)
                    {
                        ResponsableDTO rDTO = new ResponsableDTO();

                        rDTO.id = responable.id;
                        rDTO.nombre = responable.nombre;
                        rDTO.apellido = responable.apellido;
                        rDTO.baja = responable.baja;
                        fuenteDTO.responsables.Add(rDTO);
                    } 
                    fuenteDTO.baja = fuente.baja;
                    fuentesDTO.Add(fuenteDTO);
                }
                
                return fuentesDTO;
                 
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
 
            } 
        }


        [HttpPost]
        public ActionResult<int> DarDeAltaFuenteFinanciamiento([FromBody] FuenteFinanciamientoAltaDTO fuenteFinanciamientoDTO)
        {
            try
            {
                FuenteFinanciamiento fuente = new  FuenteFinanciamiento();
                fuente.saldo = fuenteFinanciamientoDTO.saldo; 
                fuente.motivo = fuenteFinanciamientoDTO.motivo;
                fuente.observaciones = fuenteFinanciamientoDTO.observaciones;
                fuente.fecha_acreditacion = fuenteFinanciamientoDTO.fecha_acreditacion;
                fuente.tipoFondo  = new TipoFondo();
                fuente.tipoFondo  = new TipoFondoServicio(context).cargarPorId(fuenteFinanciamientoDTO.tipoFondoId);
                fuente.movimientos = new List<Movimiento>();  
                fuente.proyecto = new Proyecto();
                fuente.proyecto = new ProyectoServicio(context).cargarPorId(fuenteFinanciamientoDTO.proyectoId);
                fuente.responsables = new List<Responsable>();
                
                 int id = servicio.DarDeAltaFuenteFinanciamiento(fuente);
                 
                return id;
                 
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
                 
            } 
        }


        [HttpPut]
        public ActionResult ModificarFuenteFinanciamiento([FromBody] FuenteFinanciamientoModificarDTO fuenteFinanciamientoDTO)
        {
            try
            {
                FuenteFinanciamiento fuente = new FuenteFinanciamiento();
                fuente.id = fuenteFinanciamientoDTO.id;
                fuente.saldo = fuenteFinanciamientoDTO.saldo;
                fuente.fecha_acreditacion = fuenteFinanciamientoDTO.fecha_acreditacion;
                fuente.motivo = fuenteFinanciamientoDTO.motivo;
                fuente.observaciones = fuenteFinanciamientoDTO.observaciones;
                fuente.tipoFondo = new TipoFondo();
                fuente.tipoFondo = new TipoFondoServicio(context).cargarPorId(fuenteFinanciamientoDTO.tipoFondoId);
                fuente.proyecto = new Proyecto();
                fuente.proyecto = new ProyectoServicio(context).cargarPorId(fuenteFinanciamientoDTO.proyectoId);

                servicio.ModificarFuenteFinanciamiento(fuente);

                return Ok();
                 
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
                 
            } 
        }



        [HttpDelete("id:int")]
        public ActionResult DarDeBajaFuenteFinanciamiento(int id)
        {
            try
            { 
                servicio.DarDeBajaFuenteFinanciamiento(id);
                 
                return Ok(); 
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
                 
            } 
        }
    }
}