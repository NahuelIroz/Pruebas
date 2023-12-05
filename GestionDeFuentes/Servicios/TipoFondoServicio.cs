using GestionDeFuentes.Context;
using GestionDeFuentes.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeFuentes.Servicios
{
    public class TipoFondoServicio
    {  private readonly GestionDeFuentesContext context;
        public TipoFondoServicio(GestionDeFuentesContext Context)
        {
            context = Context;
        }

        public TipoFondo cargarPorId(int id)
        {
            return context.TipoFondo.FirstOrDefault(i => i.id == id);
        }

        public int DarDeAltaTipoFondo(TipoFondo tipoFondo)
        {
            try
            {
                tipoFondo.baja = false;
                context.TipoFondo.Add(tipoFondo);
                context.SaveChanges();
                return tipoFondo.id;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public List<TipoFondo> ObtenerListadoDeTipoFondo()
        {
            try
            {
                List<TipoFondo> listaDeTiposFondos = context.TipoFondo.Where(e => e.baja == false).ToList();

                return listaDeTiposFondos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void ModificarTipoFondo(TipoFondo tipoFondoModificado)
        {
            try
            {                 // obtengo el obj a modificar ->
                TipoFondo tipoFondoOriginal = context.TipoFondo.FirstOrDefault(i => i.id == tipoFondoModificado.id && i.baja == false);
                // verifico
                if (tipoFondoOriginal == null)
                {
                    throw new Exception("Error,el tipo de fondo no existe");
                }

                // modifico y guardo los cambios ->
                tipoFondoOriginal.codigo = tipoFondoModificado.codigo;
                tipoFondoOriginal.descripcion = tipoFondoModificado.descripcion; 
                context.TipoFondo.Update(tipoFondoOriginal);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DarDeBajaTipoFondo(int idTipoFondo)
        {
            try
            {
                TipoFondo tipoFondoOriginal = context.TipoFondo.FirstOrDefault(i => i.id == idTipoFondo);

                if (tipoFondoOriginal != null)
                {
                    if (tipoFondoOriginal.baja)
                    { 
                        throw new Exception("Error, el tipo de fondo no existe");
                    }
                    tipoFondoOriginal.baja = true;
                    context.Update(tipoFondoOriginal);
                    context.SaveChanges();
                }
                else throw new Exception("Error, el tipo de fondo no existe");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}