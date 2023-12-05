using GestionDeFuentes.Modelo;

namespace WebAPI.DTOs
{
    public class ProyectoDTO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public bool baja { get; set; }
        public virtual List<FuenteFinanciamientoDTO> fuentesFinanciamiento { get; set; }

    }
}
