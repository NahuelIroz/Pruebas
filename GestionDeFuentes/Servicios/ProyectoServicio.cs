using GestionDeFuentes.Context;
using GestionDeFuentes.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeFuentes.Servicios
{
    public class ProyectoServicio
    {
        private readonly GestionDeFuentesContext context;
        public ProyectoServicio(GestionDeFuentesContext Context)
        {
            context = Context;
        }
        public Proyecto cargarPorId(int id)
        {
            return context.Proyecto.FirstOrDefault(p => p.id == id);

        }

        public int DarDeAltaProyecto(Proyecto proyecto)
        {
            try
            {
                proyecto.baja = false;
                context.Proyecto.Add(proyecto);
                context.SaveChanges();
                return proyecto.id;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Proyecto> ObtenerListadoDeProyectos()
        {
            try
            {
                List<Proyecto> listaDeProyectos = context.Proyecto.Where(e => e.baja == false).ToList();

                return listaDeProyectos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void ModificarProyecto(Proyecto proyectoModificado)
        {
            try
            {
                // obtengo el obj a modificar ->
                Proyecto proyectoOriginal = context.Proyecto.FirstOrDefault(p => p.id == proyectoModificado.id && p.baja == false);

                // verifico
                if (proyectoOriginal == null)
                {
                    throw new Exception("Error,el proyecto no existe");
                } 
                // modifico y guardo los cambios ->
                proyectoOriginal.nombre = proyectoModificado.nombre;

                context.Proyecto.Update(proyectoOriginal);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DarDeBajaProyecto(int idProyecto)
        {
            try
            {

                Proyecto proyectoOriginal = context.Proyecto.FirstOrDefault(p => p.id == idProyecto);
                if (proyectoOriginal != null)
                {
                    if (proyectoOriginal.baja)
                    {
                        throw new Exception("Error,el proyecto ya fue dado de baja");
                    }
                    proyectoOriginal.baja = true;
                    context.Update(proyectoOriginal);
                    context.SaveChanges();

                }
                else throw new Exception("Error, el proyecto no existe");

            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
