using GestionDeFuentes.Context;
using GestionDeFuentes.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeFuentes.Servicios
{
    public class FuenteFinanciamientoServicio
    {  private readonly GestionDeFuentesContext context;
        public FuenteFinanciamientoServicio(GestionDeFuentesContext Context)
        {
            context = Context;
        }

        public FuenteFinanciamiento cargarPorId(int id)
        {
            return context.FuenteFinanciamiento.FirstOrDefault(e => e.id == id);
        }

        public int DarDeAltaFuenteFinanciamiento(FuenteFinanciamiento fuenteFinanciamiento)
        {
            try
            {
                fuenteFinanciamiento.baja = false;
                context.FuenteFinanciamiento.Add(fuenteFinanciamiento);
                context.SaveChanges();
                return fuenteFinanciamiento.id;
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
        }

        public void ModificarFuenteFinanciamiento(FuenteFinanciamiento fuenteModificada)
        {
            try
            {                 // obtengo el obj a modificar ->
                FuenteFinanciamiento FuenteOriginal = context.FuenteFinanciamiento.FirstOrDefault(f => f.id == fuenteModificada.id && f.baja==false);
                // verifico
                if (FuenteOriginal == null)
                {
                    throw new Exception("Error,fuente de financiamiento no existe");
                }

                // modifico y guardo los cambios ->
                FuenteOriginal.fecha_acreditacion = fuenteModificada.fecha_acreditacion;
                FuenteOriginal.saldo = fuenteModificada.saldo;
                FuenteOriginal.motivo = fuenteModificada.motivo;
                FuenteOriginal.tipoFondo = fuenteModificada.tipoFondo;
                FuenteOriginal.proyecto = fuenteModificada.proyecto;
                FuenteOriginal.observaciones = fuenteModificada.observaciones;
                context.FuenteFinanciamiento.Update(fuenteModificada);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<FuenteFinanciamiento> ObtenerListadoDeFuentesFinanciamientoDeProyecto(int idProyecto)
        {
            try
            {
                List<FuenteFinanciamiento> listaDeFuentesFinanciamiento = context.FuenteFinanciamiento.Where(e => e.proyecto.id == idProyecto && e.baja == false).ToList();

                return listaDeFuentesFinanciamiento;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void DarDeBajaFuenteFinanciamiento(int idFuente)
        {
            try
            {
                FuenteFinanciamiento FuenteOrinal = context.FuenteFinanciamiento.FirstOrDefault(f => f.id == idFuente );

                if (FuenteOrinal != null)
                {
                    if (FuenteOrinal.baja)
                    { 
                        throw new Exception("Error, la fuente de financiamiento ya fue dada de baja"); 
                    }
                   FuenteOrinal.baja = true;
                    context.Update(FuenteOrinal);
                    context.SaveChanges();
                }
                else throw new Exception("Error,la fuente de financiamiento no existe");
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
        }
    }
}
    

