using GestionDeFuentes.Context;
using GestionDeFuentes.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeFuentes.Servicios
{
    public class TipoMovimientoServicio
    { private readonly GestionDeFuentesContext context;
        public TipoMovimientoServicio(GestionDeFuentesContext Context)
        {
            context = Context;
        }

        public TipoMovimiento  cargarPorId(int id)
        {
            return context.TipoMovimiento.FirstOrDefault(e => e.id == id);
        }


        public List<TipoMovimiento> ObtenerListadoDeTiposMovimiento()
        {
            try
            {
                List<TipoMovimiento> listaDeTipoMovimiento = context.TipoMovimiento.Where(e => e.baja == false).ToList();
                 
                return listaDeTipoMovimiento;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



        public int DarDeAltaTipoMovimiento(TipoMovimiento tipoMovimiento)
        {
            try
            {
                tipoMovimiento.baja = false;
                context.TipoMovimiento.Add(tipoMovimiento);
                context.SaveChanges();
                return tipoMovimiento.id;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void ModificarTipoMovimiento(TipoMovimiento tipoMovimientoModificado)
        {
            try
            {                 // obtengo el obj a modificar ->
                TipoMovimiento tipoMovimiento = context.TipoMovimiento.FirstOrDefault(e => e.id == tipoMovimientoModificado.id && e.baja == false);
                // verifico
                 if (tipoMovimiento == null)
                 {
                     throw new Exception("Error,el tipo de movimiento no existe");
                 } 

                // modifico y guardo los cambios ->
                tipoMovimiento.codigo = tipoMovimientoModificado.codigo;
                tipoMovimiento.descripcion = tipoMovimientoModificado.descripcion;
                tipoMovimiento.baja = false;
                context.TipoMovimiento.Update(tipoMovimiento);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DarDeBajaTipoMovimiento(int idTipoMovimiento)
        {
            try
            {
                TipoMovimiento tipoMovimiento = context.TipoMovimiento.FirstOrDefault(e => e.id == idTipoMovimiento);

                if (tipoMovimiento != null)
                {
                    if (tipoMovimiento.baja)
                    { 
                        throw new Exception("Error, el tipo de movimiento ya fue dado de baja");
                    }
                    tipoMovimiento.baja = true;
                    context.Update(tipoMovimiento);
                    context.SaveChanges();
                }
                else throw new Exception("Error, el tipo de movimiento no existe");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
