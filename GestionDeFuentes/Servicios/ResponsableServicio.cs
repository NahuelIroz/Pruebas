using GestionDeFuentes.Context;
using GestionDeFuentes.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeFuentes.Servicios
{
    public class ResponsableServicio
    {
        private readonly GestionDeFuentesContext context;
        public ResponsableServicio(GestionDeFuentesContext Context)
        {
            context = Context;
        }

        public Responsable cargarPorId(int id)
        {
            return context.Responsable.FirstOrDefault(r => r.id == id);

        }

        public int DarDeAltaResponsable(Responsable responsable)
        {
            try
            {
                responsable.baja=false;  
                context.Responsable.Add(responsable);
                context.SaveChanges();
                return responsable.id;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Responsable> ObtenerListadoDeResponsables()
        {
            try
            {
                List<Responsable> listaDeResponsables = context.Responsable.Where(e => e.baja == false).ToList();

                return listaDeResponsables;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void ModificarResponsable(Responsable responsableModificado)
        {
            try
            {
                // obtengo el obj a modificar ->
                Responsable responsableOriginal = context.Responsable.FirstOrDefault(r => r.id == responsableModificado.id && r.baja==false);

                // verifico
                if (responsableOriginal == null)
                 {
                    throw new Exception("Error, el responsable no existe");
                } 

                // modifico y guardo los cambios ->
                responsableOriginal.nombre = responsableModificado.nombre;
                responsableOriginal.apellido = responsableModificado.apellido;
                context.Responsable.Update(responsableOriginal);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DarDeBajaResponsable(int idResponsable)
        {
            try
            {
                Responsable ResponsableOriginal = context.Responsable.FirstOrDefault(r => r.id == idResponsable);


                if (ResponsableOriginal != null)
                {
                    if (ResponsableOriginal.baja)
                    {
                        throw new Exception("Error, el responsable ya fue dado de baja"); 
                    }
                    ResponsableOriginal.baja = true;

                    context.Update(ResponsableOriginal);
                    context.SaveChanges();

                }
                else throw new Exception("Error, el responsable no existe");

            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

