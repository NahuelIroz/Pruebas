using GestionDeFuentes.Context;
using GestionDeFuentes.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeFuentes.Servicios
{
    public class MovimientoServicio
    { private readonly GestionDeFuentesContext context;
        public MovimientoServicio(GestionDeFuentesContext Context)
        {
            context = Context;
        }
        public Movimiento cargarPorId(int id)
        {
            return context.Movimiento.FirstOrDefault(c => c.id == id);
            
        }

        public int DarDeAltaMovimiento(Movimiento movimiento)
        {
            try
            {
                movimiento.baja = false;
                context.Movimiento.Add(movimiento);
                context.SaveChanges();
                return movimiento.id;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public List<Movimiento> ObtenerListadoDeMovimientosDeFuenteDeFinanciamiento(int idFuenteFinanciamiento)
        {
            try
            {
                List<Movimiento> listaDeMovimiento = context.Movimiento.Where(e => e.fuenteFinanciamiento.id == idFuenteFinanciamiento && e.baja==false).ToList();

                return listaDeMovimiento;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void ModificarMovimiento(Movimiento movimientoModificada)
        {
            try
            {
                // obtengo el obj a modificar ->
                Movimiento movimientoOriginal = context.Movimiento.FirstOrDefault(c => c.id == movimientoModificada.id && c.baja==false);

                // verifico
                if (movimientoOriginal == null)
                 {
                     throw new Exception("Error,el movimiento no existe");
                 } 

                // modifico y guardo los cambios ->
                movimientoOriginal.descripcion = movimientoModificada.descripcion;
                movimientoOriginal.saldo = movimientoModificada.saldo;
                movimientoOriginal.tipoMovimiento = movimientoModificada.tipoMovimiento;
                context.Movimiento.Update(movimientoOriginal);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DarDeBajaMovimiento(int idMovimiento)
        {
            try
            {

                Movimiento movimientoOriginal = context.Movimiento.FirstOrDefault(c => c.id == idMovimiento);
                if (movimientoOriginal != null)
                {
                    if (movimientoOriginal.baja) throw new Exception("El movimiento ya fue dado de baja");
                     
                        movimientoOriginal.baja = true;
                        context.Update(movimientoOriginal);
                        context.SaveChanges();
                  
                }
                else throw new Exception("Error, el movimiento no existe");

            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
