using System;
using TallerBiblioteca.Domain.Tiempo;

namespace TallerBiblioteca.Domain.Modelos
{
    public class Ejemplar : Entidad
    {
        /// <summary>
        /// Edicion de la cual es un ejemplar
        /// </summary>
        public virtual Edicion Edicion { get; set; }

        /// <summary>
        /// Código de inventario del ejemplar.
        /// Ambos, el id y este campo son posibles códigos de inventario.
        /// </summary>
        public string CodigoInventario { get; set; }

        /// <summary>
        /// Fecha que se dio de alta el ejemplar
        /// </summary>
        public DateTime FechaAlta { get; set; }

        /// <summary>
        /// Fecha que se dio de baja el ejemplar, o nula.
        /// </summary>
        public DateTime? FechaBaja { get; set; }

        /// <summary>
        /// Da de baja el ejemplar
        /// </summary>
        /// <param name="dateTimeProvider"></param>
        public void DarDeBaja(IDateTimeProvider dateTimeProvider)
        {
            this.FechaBaja = dateTimeProvider.Now;
        }
    }
}
