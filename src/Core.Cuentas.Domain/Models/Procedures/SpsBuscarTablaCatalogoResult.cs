using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Cuentas.Domain.Models.Procedures
{
    public class SpsBuscarTablaCatalogoResult
    {
        [Column("JsonData")]
        public string JsonData { get; set; } = string.Empty;
    }
}
